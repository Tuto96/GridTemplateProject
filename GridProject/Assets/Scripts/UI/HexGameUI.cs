using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HexGameUI : MonoBehaviour
{

	HexCell currentCell, previousCell;

	HexUnit selectedUnit;

	UnitInfoScreen unitInfo;

	public HexGrid grid;

	public bool isMoving { get; private set; }

	public bool isAttacking { get; private set; }

	public OptionsMenu optMenu;

	Button endTurnButton;

	void Update ()
	{
		if (!EventSystem.current.IsPointerOverGameObject ())
		{
			if (Input.GetKeyDown (KeyCode.F))
			{
				UpdateCurrentCell ();
				HexMapCamera.instance.Focus (currentCell);
			}
			if (Input.GetMouseButtonDown (0))
			{
				if (selectedUnit && isMoving)
				{
					DoMove ();
				}
				else if (selectedUnit && isAttacking)
				{
					DoAttack ();
				}
				else
				{
					DoSelection ();
				}
			}
			else if (selectedUnit)
			{
				if (isMoving)
				{
					DoPathfinding ();
				}
			}
		}

		if (Input.GetKeyUp (KeyCode.C))
		{
			RotatePrev ();
		}
		else if (Input.GetKeyUp (KeyCode.Z))
		{
			RotateNext ();
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

		if (GameManager.instance.currentTeamIndex > 0)
		{
			endTurnButton.gameObject.SetActive (false);
		}
		else
		{
			endTurnButton.gameObject.SetActive (true);
		}
	}

	public void RotateNext ()
	{
		if (selectedUnit)
		{
			selectedUnit.rotateNext ();
			DoPathfinding ();
		}
	}

	public void RotatePrev ()
	{
		if (selectedUnit)
		{
			selectedUnit.rotatePrev ();
			DoPathfinding ();
		}
	}

	void Awake ()
	{
		Shader.DisableKeyword ("HEX_MAP_EDIT_MODE");
		unitInfo = FindObjectOfType<UnitInfoScreen> ();
		endTurnButton = transform.Find ("End Turn Button").GetComponent<Button> ();
	}

	void OnEnable ()
	{
		GameManager.Require ();
	}

	public void SetEditMode (bool toggle)
	{
		enabled = !toggle;
		grid.ShowUI (!toggle);
		grid.ClearPath ();
		unitInfo.EditMode = !toggle;
		endTurnButton.enabled = !toggle;
		GameManager.instance.isEditMode = toggle;
		gameObject.SetActive (!toggle);
		if (toggle)
		{
			Shader.EnableKeyword ("HEX_MAP_EDIT_MODE");
		}
		else
		{

		}
	}

	public void SetIsMoving ()
	{
		isMoving = true;
		isAttacking = false;
	}

	public void SetIsAttacking ()
	{
		isAttacking = true;
		isMoving = false;
		GetTargets ();
	}

	public void EndTurn ()
	{
		GameManager.instance.EndTurn ();
	}

	void GetTargets ()
	{
		if (selectedUnit.team.isPlayerControlled)
		{
			selectedUnit.GetTargets ();
		}
	}
	private void DoAttack ()
	{
		UpdateCurrentCell ();
		if (currentCell && currentCell.Unit)
		{
			selectedUnit.Attack (currentCell);
		}
	}

	bool UpdateCurrentCell ()
	{
		HexCell cell = grid.GetCell (Camera.main.ScreenPointToRay (Input.mousePosition));
		if (cell != currentCell)
		{
			previousCell = currentCell;
			currentCell = cell;
			return true;
		}
		else if (selectedUnit && selectedUnit.valuesChanged)
		{
			selectedUnit.valuesChanged = false;
			return true;
		}
		return false;
	}

	void DoSelection ()
	{
		grid.ClearFullPath ();
		if (selectedUnit)
		{
			selectedUnit.Location.DisableHighlight ();
		}

		UpdateCurrentCell ();
		if (currentCell)
		{
			selectedUnit = currentCell.Unit;
			unitInfo.Unit = selectedUnit;
		}
	}

	void DoPathfinding ()
	{
		if (selectedUnit.team.isPlayerControlled)
		{
			if (UpdateCurrentCell ())
			{
				if (currentCell && selectedUnit.IsValidDestination (currentCell))
				{
					grid.FindPath (selectedUnit.Location, currentCell, selectedUnit);
				}
				else
				{
					grid.ClearPath ();
					if (previousCell) previousCell.DisableHighlight ();
				}
			}
		}
	}

	void DoMove ()
	{
		if (grid.HasPath)
		{
			selectedUnit.Travel (grid.GetPath ());
			grid.ClearPath ();
		}
		else
		{
			DoSelection ();
		}
	}
}