using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;


public class HexMapEditor : MonoBehaviour
{

    public HexGrid hexGrid;

    public OptionsMenu optMenu;

    public Material terrainMaterial;

    public HexUnit[] units;

    private HexUnit spawnUnit;

    private int activeElevation;

    int activeUrbanLevel, activeFarmLevel, activePlantLevel, activeSpecialIndex, activeTerrainTypeIndex, activeTeam;

    int activeWaterLevel;

    bool applyElevation = true;

    bool applyUrbanLevel, applyFarmLevel, applyPlantLevel, applySpecialIndex;

    bool applyWaterLevel = true;

    int brushSize;

    enum OptionalToggle
    {
        Ignore,
        Yes,
        No
    }

    OptionalToggle riverMode, roadMode, walledMode;

    bool isDrag;
    HexDirection dragDirection;
    HexCell previousCell;

    #region UI Methods

    public void ClearExplored ()
    {
        Debug.Log ("reseting exploration");
        GameManager.instance.grid.ResetExploration ();
    }

    public void SetTerrainTypeIndex (int index)
    {
        activeTerrainTypeIndex = index;
    }
    public void SetTeam (float index)
    {
        activeTeam = (int) index;
    }

    public void SetRiverMode (int mode)
    {
        riverMode = (OptionalToggle) mode;
    }

    public void SetBrushSize (float size)
    {
        brushSize = (int) size;
    }

    public void SetRoadMode (int mode)
    {
        roadMode = (OptionalToggle) mode;
    }

    public void SetApplyWaterLevel (bool toggle)
    {
        applyWaterLevel = toggle;
    }

    public void SetWaterLevel (float level)
    {
        activeWaterLevel = (int) level;
    }

    public void SetElevation (float elevation)
    {
        activeElevation = (int) elevation;
    }

    public void SetApplyElevation (bool toggle)
    {
        applyElevation = toggle;
    }

    public void SetApplyUrbanLevel (bool toggle)
    {
        applyUrbanLevel = toggle;
    }

    public void SetUrbanLevel (float level)
    {
        activeUrbanLevel = (int) level;
    }

    public void SetApplyFarmLevel (bool toggle)
    {
        applyFarmLevel = toggle;
    }

    public void SetFarmLevel (float level)
    {
        activeFarmLevel = (int) level;
    }

    public void SetApplyPlantLevel (bool toggle)
    {
        applyPlantLevel = toggle;
    }

    public void SetPlantLevel (float level)
    {
        activePlantLevel = (int) level;
    }

    public void SetApplySpecialIndex (bool toggle)
    {
        applySpecialIndex = toggle;
    }

    public void SetSpecialIndex (float index)
    {
        activeSpecialIndex = (int) index;
    }

    public void SetWalledMode (int mode)
    {
        walledMode = (OptionalToggle) mode;
    }

    public void SetEditMode (bool toggle)
    {
        GameManager.instance.isEditMode = toggle;
        gameObject.SetActive (toggle);
    }

    public void ShowGrid (bool visible)
    {
        if (visible)
        {
            terrainMaterial.EnableKeyword ("GRID_ON");
        }
        else
        {
            terrainMaterial.DisableKeyword ("GRID_ON");
        }
    }

    #endregion

    void Awake ()
    {
        terrainMaterial.DisableKeyword ("GRID_ON");
    }

    void Update ()
    {
        if (!EventSystem.current.IsPointerOverGameObject ())
        {
            if (Input.GetMouseButton (0))
            {
                HandleInput ();
                return;
            }
            if (Input.GetKeyDown (KeyCode.U))
            {
                if (Input.GetKey (KeyCode.LeftShift))
                {
                    DestroyUnit ();
                }
                else
                {
                    spawnUnit = units[0];
                    CreateUnit ();
                }
                return;
            }
            else if (Input.GetKeyDown (KeyCode.I))
            {
                if (Input.GetKey (KeyCode.LeftShift))
                {
                    DestroyUnit ();
                }
                else
                {
                    spawnUnit = units[1];
                    CreateUnit ();
                }
                return;
            }
            else if (Input.GetKeyDown (KeyCode.O))
            {
                if (Input.GetKey (KeyCode.LeftShift))
                {
                    DestroyUnit ();
                }
                else
                {
                    spawnUnit = units[2];
                    CreateUnit ();
                }
                return;
            }
            else if (Input.GetKeyDown (KeyCode.P))
            {
                if (Input.GetKey (KeyCode.LeftShift))
                {
                    DestroyUnit ();
                }
                else
                {
                    spawnUnit = units[3];
                    CreateUnit ();
                }
                return;
            }
        }
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (optMenu.gameObject.activeInHierarchy)
            {
                optMenu.Close ();
            }
            else
            {
                optMenu.Open ();
            }
        }
        previousCell = null;
    }

    void HandleInput ()
    {
        HexCell currentCell = GetCellUnderCursor ();
        if (currentCell)
        {
            if (previousCell && previousCell != currentCell)
            {
                ValidateDrag (currentCell);
            }
            else
            {
                isDrag = false;
            }
            EditCells (currentCell);
            previousCell = currentCell;
        }
        else
        {
            previousCell = null;
        }
    }

    HexCell GetCellUnderCursor ()
    {
        return hexGrid.GetCell (Camera.main.ScreenPointToRay (Input.mousePosition));
    }

    void CreateUnit ()
    {
        HexCell cell = GetCellUnderCursor ();
        if (cell && !cell.Unit)
        {
            HexUnit myUnit = GameManager.instance.teams[activeTeam].AddUnit (
                Instantiate (spawnUnit), cell, (HexDirection) Random.Range (0, 6)
            );
            myUnit.name = spawnUnit.name;
            myUnit.TeamIndex = activeTeam;
        }
    }

    void DestroyUnit ()
    {
        HexCell cell = GetCellUnderCursor ();
        if (cell && cell.Unit)
        {
            hexGrid.RemoveUnit (cell.Unit);
        }
    }

    void EditCells (HexCell center)
    {
        int centerX = center.coordinates.X;
        int centerZ = center.coordinates.Z;

        for (int r = 0, z = centerZ - brushSize; z <= centerZ; z++, r++)
        {
            for (int x = centerX - r; x <= centerX + brushSize; x++)
            {
                EditCell (hexGrid.GetCell (new HexCoordinates (x, z)));
            }
        }
        for (int r = 0, z = centerZ + brushSize; z > centerZ; z--, r++)
        {
            for (int x = centerX - brushSize; x <= centerX + r; x++)
            {
                EditCell (hexGrid.GetCell (new HexCoordinates (x, z)));
            }
        }
    }

    void EditCell (HexCell cell)
    {
        if (cell)
        {
            if (activeTerrainTypeIndex >= 0)
            {
                cell.TerrainTypeIndex = activeTerrainTypeIndex;
            }
            if (applyElevation)
            {
                cell.Elevation = activeElevation;
            }
            if (applyWaterLevel)
            {
                cell.WaterLevel = activeWaterLevel;
            }
            if (applySpecialIndex)
            {
                cell.SpecialIndex = activeSpecialIndex;
            }
            if (applyUrbanLevel)
            {
                cell.UrbanLevel = activeUrbanLevel;
            }
            if (applyFarmLevel)
            {
                cell.FarmLevel = activeFarmLevel;
            }
            if (applyPlantLevel)
            {
                cell.PlantLevel = activePlantLevel;
            }
            if (riverMode == OptionalToggle.No)
            {
                cell.RemoveRiver ();
            }
            if (roadMode == OptionalToggle.No)
            {
                cell.RemoveRoads ();
            }
            if (walledMode != OptionalToggle.Ignore)
            {
                cell.Walled = walledMode == OptionalToggle.Yes;
            }
            if (isDrag)
            {
                HexCell otherCell = cell.GetNeighbor (dragDirection.Opposite ());
                if (otherCell)
                {
                    if (riverMode == OptionalToggle.Yes)
                    {
                        otherCell.SetOutgoingRiver (dragDirection);
                    }
                    if (roadMode == OptionalToggle.Yes)
                    {
                        otherCell.AddRoad (dragDirection);
                    }
                }
            }
        }
    }

    void ValidateDrag (HexCell currentCell)
    {
        for (
            dragDirection = HexDirection.NE; dragDirection <= HexDirection.NW; dragDirection++
        )
        {
            if (previousCell.GetNeighbor (dragDirection) == currentCell)
            {
                isDrag = true;
                return;
            }
        }
        isDrag = false;
    }
}