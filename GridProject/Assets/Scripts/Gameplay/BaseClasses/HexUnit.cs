using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class HexUnit : MonoBehaviour
{
	#region Stats Modifiers

	[HideInInspector]
	public float plusStrength;
	[HideInInspector]
	public float plusAgility;
	[HideInInspector]
	public float plusIntelligence;
	[HideInInspector]
	public float plusHealth;
	[HideInInspector]
	public float plusAP;
	[HideInInspector]
	public float plusMana;
	[HideInInspector]
	public float plusMeleeDmg;
	[HideInInspector]
	public float plusRangedDmg;
	[HideInInspector]
	public float plusMagicDmg;
	[HideInInspector]
	public float plusMeleeDef;
	[HideInInspector]
	public float plusRangedDef;
	[HideInInspector]
	public float plusMagicDef;
	[HideInInspector]
	public float plusMoveSpeed;
	[HideInInspector]
	public float plusAttackSpeed;
	[HideInInspector]
	public float plusEvasion;
	[HideInInspector]
	public float multStrength;
	[HideInInspector]
	public float multAgility;
	[HideInInspector]
	public float multIntelligence;
	[HideInInspector]
	public float multHealth;
	[HideInInspector]
	public float multAP;
	[HideInInspector]
	public float multMana;
	[HideInInspector]
	public float multMeleeDmg;
	[HideInInspector]
	public float multRangedDmg;
	[HideInInspector]
	public float multMagicDmg;
	[HideInInspector]
	public float multMeleeDef;
	[HideInInspector]
	public float multRangedDef;
	[HideInInspector]
	public float multMagicDef;
	[HideInInspector]
	public float multMoveSpeed;
	[HideInInspector]
	public float multAttackSpeed;
	[HideInInspector]
	public float multEvasion;

	#endregion

	#region Unit Stats

	public BaseRace unitRace;

	//public HexUnitStats myStats;
	public Sprite portrait;

	public float Strength
	{
		get
		{
			float baseStrength = unitRace.baseStrength;
			return (baseStrength * (1 + multStrength)) + plusStrength;
		}
	}

	public float Agility
	{
		get
		{
			float baseAgility = unitRace.baseAgility;
			return (baseAgility * (1 + multAgility)) + plusAgility;
		}
	}

	public float Intelligence
	{
		get
		{
			float baseIntelligence = unitRace.baseIntelligence;
			return (baseIntelligence * (1 + multIntelligence)) + plusIntelligence;
		}
	}
	public float Health
	{
		get
		{
			float baseHealth = unitRace.baseHealth + (Strength * unitRace.multHealth);
			return (baseHealth * (1 + multHealth)) + plusHealth;
		}
	}

	public float AP
	{
		get
		{
			float baseAP = unitRace.baseAP + (Agility * unitRace.multAP);
			return (baseAP * (1 + multAP)) + plusAP;
		}
	}
	public float Mana
	{
		get
		{
			float baseMana = unitRace.baseMana + (Intelligence * unitRace.multMana);
			return (baseMana * (1 + multMana)) + plusMana;
		}
	}
	public float MeleeDmg
	{
		get
		{
			float baseMeleeDmg = unitRace.baseMeleeDmg + (Strength * unitRace.multMeleeDmg);
			return (baseMeleeDmg * (1 + multMeleeDmg)) + plusMeleeDmg;
		}
	}
	public float RangedDmg
	{
		get
		{
			float baseRangedDmg = unitRace.baseRangedDmg + (Agility * unitRace.multRangedDmg);
			return (baseRangedDmg * (1 + multRangedDmg)) + plusRangedDmg;
		}
	}
	public float MagicDmg
	{
		get
		{
			float baseMagicDmg = unitRace.baseMagicDmg + (Intelligence * unitRace.multMagicDmg);
			return (baseMagicDmg * (1 + multMagicDmg)) + plusMagicDmg;
		}
	}
	public float MeleeDef
	{
		get
		{
			float baseMeleeDef = unitRace.baseMeleeDef + (Strength * unitRace.multMeleeDef);
			return (baseMeleeDef * (1 + multMeleeDef)) + plusMeleeDef;
		}
	}
	public float RangedDef
	{
		get
		{
			float baseRangedDef = unitRace.baseRangedDef + (Agility * unitRace.multRangedDef);
			return (baseRangedDef * (1 + multRangedDef)) + plusRangedDef;
		}
	}
	public float MagicDef
	{
		get
		{
			float baseMagicDef = unitRace.baseMagicDef + (Intelligence * unitRace.multMagicDef);
			return (baseMagicDef * (1 + multMagicDef)) + plusMagicDef;
		}
	}
	public float MoveSpeed
	{
		get
		{
			float baseMoveSpeed = unitRace.baseMoveSpeed + (Agility * unitRace.multMoveSpeed);
			return (baseMoveSpeed * (1 + multMoveSpeed)) + plusMoveSpeed;
		}
	}
	public float AttackSpeed
	{
		get
		{
			float baseAttackSpeed = unitRace.baseAttackSpeed + (Agility * unitRace.multAttackSpeed);
			return (baseAttackSpeed * (1 + multAttackSpeed)) + plusAttackSpeed;
		}
	}
	public float Evasion
	{
		get
		{
			float baseEvasion = unitRace.baseEvasion + (Agility * unitRace.multEvasion);
			return (baseEvasion * (1 + multEvasion)) + plusEvasion;
		}
	}
	public HexAttackType attackType;
	public HexAngleType attackAngle;
	public float AttackDamage
	{
		get
		{
			switch (attackType)
			{
				case HexAttackType.None:
					{
						return 0;
					}
				case HexAttackType.Melee:
					{
						return MeleeDmg;
					}
				case HexAttackType.Ranged:
					{
						return RangedDmg;
					}
				case HexAttackType.Magic:
					{
						return MagicDmg;
					}
			}
			return 0;
		}
	}
	public int attackRange;
	public int damageRange;
	public bool hasActed, hasMoved, turnEnded;
	public int roadCost = 3;
	public int hillCost = 10;
	public int flatCost = 5;
	public int riverCost = -1;
	public int cliffCost = -1;
	public int wallCost = -1;
	public HexGrid Grid { get; set; }
	public int visionRange = 3;
	public HexAngleType visionAngle;
	public bool canSeeTruWalls = false;

	#endregion

	#region Inventory

	private Weapon equipWeapon;
	public Weapon EquipWeapon
	{
		set
		{
			if (equipWeapon)
			{
				equipWeapon.UnEquip (this);
			}
			equipWeapon = value;
			equipWeapon.Equip (this);
		}
	}

	private HeadPiece equipHead;
	public HeadPiece EquipHead
	{
		set
		{
			if (equipHead)
			{
				equipHead.UnEquip (this);
			}
			equipHead = value;
			equipHead.Equip (this);
		}
	}

	private ChestPiece equipChest;
	public ChestPiece EquipChest
	{
		set
		{
			if (equipChest)
			{
				equipChest.UnEquip (this);
			}
			equipChest = value;
			equipChest.Equip (this);
		}
	}

	private ArmPiece equipArm;
	public ArmPiece EquipArm
	{
		set
		{
			if (equipArm)
			{
				equipArm.UnEquip (this);
			}
			equipArm = value;
			equipArm.Equip (this);
		}
	}

	private LegsPiece equipLegs;
	public LegsPiece EquipLegs
	{
		set
		{
			if (equipLegs)
			{
				equipLegs.UnEquip (this);
			}
			equipLegs = value;
			equipLegs.Equip (this);
		}
	}

	private FeetPiece equipFeet;
	public FeetPiece EquipFeet
	{
		set
		{
			if (equipFeet)
			{
				equipFeet.UnEquip (this);
			}
			equipFeet = value;
			equipFeet.Equip (this);
		}
	}

	#endregion

	#region Gameplay Variables
	public Team team { get; private set; }
	const float travelSpeed = 4f;
	public int spentPoints = 0;
	private int teamIndex;
	public bool isCurrentTurn { get; private set; }
	public bool valuesChanged = false;
	public HexUnitState currentState { get; private set; }
	List<HexCell> pathToTravel;
	public UnitInfoScreen infoScreen;
	public float sustainedDamage;

	private List<HexCell> targets = new List<HexCell> ();

	#endregion

	#region Properties

	public int ActionPoints
	{
		get
		{
			return (int) AP - spentPoints;
		}
	}

	public HexCell Location
	{
		get
		{
			return location;
		}
		set
		{
			if (location)
			{
				Grid.DecreaseVisibility (location, this);
				location.Unit = null;
			}
			location = value;
			value.Unit = this;
			if (team.PlayerShareVisibility ()) Grid.IncreaseVisibility (value, this);
			transform.localPosition = value.Position;
		}
	}

	HexCell location;
	HexCell currentTravelLocation;

	HexDirection orientation;
	public HexDirection Direction
	{
		get
		{
			return orientation;
		}
		set
		{
			orientation = value;
			transform.localRotation = Quaternion.Euler (0f, (int) value * 60 + 120, 0f);
		}
	}

	public int TeamIndex
	{
		get
		{
			return teamIndex;
		}
		set
		{
			teamIndex = value;
			team = GameManager.instance.teams[teamIndex];
		}
	}

	#endregion

	#region Initialization and Settings
	void OnEnable ()
	{
		isCurrentTurn = false;
		if (location)
		{
			transform.localPosition = location.Position;
			currentState = HexUnitState.Idle;
			if (currentTravelLocation)
			{
				Grid.IncreaseVisibility (location, this);
				Grid.DecreaseVisibility (currentTravelLocation, this);
				currentTravelLocation = null;
			}
		}
		targets.Clear ();
	}

	public void SetColor (Color newColor)
	{
		foreach (Renderer r in GetComponentsInChildren<Renderer> ())
		{
			r.material.color = newColor;
		}
	}

	#endregion

	#region Movement

	public void rotatePrev ()
	{
		if (ActionPoints >= 1)
		{
			Grid.DecreaseVisibility (location, this);
			Direction = Direction.Previous ();
			Grid.IncreaseVisibility (location, this);
			spentPoints++;
			valuesChanged = true;
			infoScreen.UpdateValues ();
		}
	}

	public void rotateNext ()
	{
		if (ActionPoints >= 1)
		{
			Grid.DecreaseVisibility (location, this);
			Direction = Direction.Next ();
			Grid.IncreaseVisibility (location, this);
			spentPoints++;
			valuesChanged = true;
			infoScreen.UpdateValues ();
		}
	}

	public int GetMoveCost (HexCell fromCell, HexCell toCell, HexDirection direction)
	{
		int moveCost = 0;
		HexEdgeType edgeType = fromCell.GetEdgeType (toCell);
		if (edgeType == HexEdgeType.Cliff)
		{
			if (cliffCost < 0)
				return -1;
			moveCost += cliffCost;
		}
		if (fromCell.HasRoadThroughEdge (direction))
		{
			return roadCost;
		}
		else if (fromCell.Walled != toCell.Walled)
		{
			if (wallCost < 0)
				return -1;
			moveCost += wallCost;
		}
		else
		{
			moveCost = edgeType == HexEdgeType.Flat ? flatCost : hillCost;
			moveCost += toCell.UrbanLevel + toCell.FarmLevel + toCell.PlantLevel;
		}
		return moveCost;
	}

	public void Travel (List<HexCell> path)
	{
		if (currentState == HexUnitState.Idle && !hasMoved)
		{
			location.Unit = null;
			location = path[path.Count - 1];
			location.Unit = this;
			pathToTravel = path;
			currentState = HexUnitState.Moving;
			StopAllCoroutines ();
			StartCoroutine (TravelPath ());
		}
	}

	IEnumerator TravelPath ()
	{
		Grid.DecreaseVisibility (currentTravelLocation ? currentTravelLocation : pathToTravel[0], this);
		pathToTravel[0].DisableHighlight ();
		for (int i = 1; i < pathToTravel.Count; i++)
		{
			currentTravelLocation = pathToTravel[i];
			HexCell A = currentTravelLocation;
			HexCell B = pathToTravel[i - 1];
			Direction = A.GetHexDirection (B);

			spentPoints += GetMoveCost (A, B, Direction);

			Vector3 a = pathToTravel[i - 1].Position;
			Vector3 b = currentTravelLocation.Position;

			float t = Time.deltaTime * travelSpeed;
			Grid.IncreaseVisibility (pathToTravel[i], this);
			if (infoScreen)
			{
				// if the infocreen is not null, we still have the unit selected after travel.
				B.EnableHighlight (GameManager.instance.selectedCellColor);
				infoScreen.UpdateValues ();
			}
			for (; t < 1f; t += Time.deltaTime * travelSpeed)
			{
				transform.localPosition = Vector3.Lerp (a, b, t);
				yield return null;
			}
			Grid.DecreaseVisibility (pathToTravel[i], this);
			B.DisableHighlight ();
			t -= 1f;
		}
		if (infoScreen)
		{
			// if the infocreen is not null, we still have the unit selected after travel.
			location.EnableHighlight (GameManager.instance.selectedCellColor);
			infoScreen.UpdateValues ();
		}
		currentTravelLocation = null;
		transform.localPosition = location.Position;
		Grid.IncreaseVisibility (location, this);
		hasMoved = true;
		currentState = HexUnitState.Idle;
	}

	public bool IsValidDestination (HexCell cell)
	{
		return cell.IsExplored && !cell.IsUnderwater && !cell.Unit;
	}

	public void ValidateLocation ()
	{
		transform.localPosition = location.Position;
	}

	#endregion

	#region Combat
	internal void GetTargets ()
	{
		foreach (HexCell cell in targets)
		{
			cell.DisableHighlight ();
		}
		targets.Clear ();
		List<HexCell> targetCells = Grid.GetCellsInRange (location, attackAngle, Direction, attackRange);
		foreach (HexCell cell in targetCells)
		{
			if (cell.Unit == null || cell.Unit.team == team)
			{
				continue;
			}
			{
				targets.Add (cell);
				cell.EnableHighlight (GameManager.instance.attackColor);
			}
		}
	}

	public float getCurrentHealth ()
	{
		//return myStats.GetStat(UnitStats.Health).GetCurrentValue() - sustainedDamage;
		return Health - sustainedDamage;
	}

	public void OnAttackHit (float dmg)
	{
		sustainedDamage += dmg;
	}

	public void Attack (HexCell targetCell)
	{
		if (targets.Contains (targetCell))
		{
			HexUnit targetUnit = targetCell.Unit;
			targetUnit.OnAttackHit (AttackDamage);
			Debug.Log ("Attacking " + targetUnit.name + " from team " + targetUnit.TeamIndex);
		}
	}

	public void Die ()
	{
		Debug.Log ("Dying");
		if (infoScreen) infoScreen.Unit = null;
		location.Unit = null;
		Grid.DecreaseVisibility (location, this);
		team.RemoveUnit (this);
		GameObject.DestroyImmediate (gameObject);
	}

	#endregion

	#region Turn Logic

	public void BeginTurn ()
	{
		hasActed = false;
		hasMoved = false;
		turnEnded = false;
		isCurrentTurn = true;
		spentPoints = 0;
		if (infoScreen) infoScreen.UpdateValues ();
	}

	public void EndTurn ()
	{
		hasActed = true;
		hasMoved = true;
		turnEnded = true;
		isCurrentTurn = false;
		if (infoScreen) infoScreen.UpdateValues ();
	}

	#endregion

	#region Save Load
	public void Save (BinaryWriter writer)
	{

		location.coordinates.Save (writer);

		writer.Write (name);
		writer.Write ((byte) TeamIndex);
		writer.Write ((byte) orientation);
		writer.Write ((byte) visionRange);
		writer.Write ((byte) visionAngle);

		writer.Write ((byte) spentPoints);
		writer.Write (hasMoved);
		writer.Write (hasActed);
		writer.Write (turnEnded);

	}

	public static void Load (BinaryReader reader, int header)
	{

		HexCoordinates coordinates = HexCoordinates.Load (reader);
		string myName = reader.ReadString ();
		int myTeamIndex = 0;
		if (header >= 5)
		{
			myTeamIndex = reader.ReadByte ();
		}
		HexDirection orientation = (HexDirection) reader.ReadByte ();

		HexUnit prefab = Resources.Load<HexUnit> ("Units/" + myName);
		HexUnit unit = GameManager.instance.teams[myTeamIndex].AddUnit (
			Instantiate (prefab), GameManager.instance.grid.GetCell (coordinates), orientation
		);

		unit.visionRange = reader.ReadByte ();
		unit.visionAngle = (HexAngleType) reader.ReadByte ();
		if (header >= 4)
		{
			unit.spentPoints = reader.ReadByte ();
			unit.hasMoved = reader.ReadBoolean ();
			unit.hasActed = reader.ReadBoolean ();
			unit.turnEnded = reader.ReadBoolean ();
		}

		unit.name = prefab.name;

		//unit.myStats.Init();
	}

	#endregion
}