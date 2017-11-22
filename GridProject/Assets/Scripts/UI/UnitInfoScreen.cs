using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoScreen : MonoBehaviour
{

	public HexMapCamera cam;

	private HexUnit unit;

	Transform originalParent;

	Image border;

	public bool EditMode
	{
		get
		{
			return editMode;
		}
		set
		{
			editMode = value;
			gameObject.SetActive (editMode);
		}
	}

	private bool editMode;

	public Sprite meleeIcon, rangedIcon, magicIcon;
	public Sprite angleNarrow, angleRegular, angleWide, angleAll;

	Image portrait, attackIcon, attackAngle, visionAngle;
	Text unitName, actionPoints, visionRange, roadCost, flatCost, hillCost, cliffCost, wallCost, attackDamage, attackRange;
	Slider healthBar;
	public HexUnit Unit
	{
		get
		{
			return unit;
		}
		set
		{
			if (value != null)
			{
				gameObject.SetActive (true);
				transform.SetParent (value.transform);
				transform.localPosition = new Vector3 (0, 12, 0);
				if (value.team.isPlayerControlled) value.Location.EnableHighlight (GameManager.instance.selectedCellColor);

				if (unit & unit != value)
				{
					unit.Location.DisableHighlight ();
					unit.infoScreen = null;
				}
				unit = value;
				SetValues ();
				unit.infoScreen = this;
			}
			else
			{
				transform.SetParent (originalParent);
				transform.localPosition = new Vector3 (0, -100, 0);
				gameObject.SetActive (false);

				if (unit)
				{
					unit.Location.DisableHighlight ();
					unit.infoScreen = null;
				}
				unit = value;
			}
		}
	}

	public void UpdateValues ()
	{
		SetValues ();
	}

	void SetValues ()
	{
		Color teamColor = unit.team.teamColor;
		teamColor.a = 1.0f;

		border.color = teamColor;

		portrait.sprite = unit.portrait;
		SetHealth ();

		unitName.text = unit.name;
		actionPoints.text = unit.ActionPoints.ToString ();

		SetVision (teamColor);

		roadCost.text = unit.roadCost.ToString ();
		flatCost.text = unit.flatCost.ToString ();
		hillCost.text = unit.hillCost.ToString ();
		cliffCost.text = unit.cliffCost.ToString ();
		wallCost.text = unit.wallCost.ToString ();

		SetAttack (teamColor);

	}

	private void SetHealth ()
	{
		healthBar.minValue = 0;
		healthBar.maxValue = unit.Health;
		healthBar.value = unit.getCurrentHealth ();
	}

	private void SetAttack (Color teamColor)
	{
		switch (unit.attackType)
		{
			case HexAttackType.Melee:
				{
					attackIcon.sprite = meleeIcon;
					attackIcon.color = teamColor;
					break;
				}
			case HexAttackType.Ranged:
				{
					attackIcon.sprite = rangedIcon;
					attackIcon.color = teamColor;
					break;
				}
			case HexAttackType.Magic:
				{
					attackIcon.sprite = magicIcon;
					attackIcon.color = teamColor;
					break;
				}
		}

		attackDamage.text = unit.AttackDamage.ToString ();

		switch (unit.attackAngle)
		{
			case HexAngleType.Narrow:
				{
					attackAngle.sprite = angleNarrow;
					attackAngle.color = teamColor;
					break;
				}
			case HexAngleType.Regular:
				{
					attackAngle.sprite = angleRegular;
					attackAngle.color = teamColor;
					break;
				}
			case HexAngleType.Wide:
				{
					attackAngle.sprite = angleWide;
					attackAngle.color = teamColor;
					break;
				}
			case HexAngleType.AllAround:
				{
					attackAngle.sprite = angleAll;
					attackAngle.color = teamColor;
					break;
				}
		}

		attackRange.text = unit.attackRange.ToString ();
	}

	private void SetVision (Color teamColor)
	{
		switch (unit.visionAngle)
		{
			case HexAngleType.Narrow:
				{
					visionAngle.sprite = angleNarrow;
					visionAngle.color = teamColor;
					break;
				}
			case HexAngleType.Regular:
				{
					visionAngle.sprite = angleRegular;
					visionAngle.color = teamColor;
					break;
				}
			case HexAngleType.Wide:
				{
					visionAngle.sprite = angleWide;
					visionAngle.color = teamColor;
					break;
				}
			case HexAngleType.AllAround:
				{
					visionAngle.sprite = angleAll;
					visionAngle.color = teamColor;
					break;
				}
		}
		visionRange.text = unit.visionRange.ToString ();
	}

	void Start ()
	{
		originalParent = transform.parent;
		border = GetComponent<Image> ();

		portrait = transform.Find ("Portrait").GetComponent<Image> ();
		healthBar = transform.Find ("Health Bar").GetComponent<Slider> ();

		unitName = transform.Find ("Panel/Unit Name").GetComponent<Text> ();
		actionPoints = transform.Find ("Panel/AP Text").GetComponent<Text> ();

		visionAngle = transform.Find ("Panel/Vision Angle").GetComponent<Image> ();
		visionRange = transform.Find ("Panel/Vision Range").GetComponent<Text> ();

		roadCost = transform.Find ("Panel/Road Cost").GetComponent<Text> ();
		flatCost = transform.Find ("Panel/Flat Cost").GetComponent<Text> ();
		hillCost = transform.Find ("Panel/Hill Cost").GetComponent<Text> ();
		cliffCost = transform.Find ("Panel/Cliff Cost").GetComponent<Text> ();
		wallCost = transform.Find ("Panel/Wall Cost").GetComponent<Text> ();

		attackIcon = transform.Find ("Panel/Attack Icon").GetComponent<Image> ();
		attackDamage = transform.Find ("Panel/Damage Text").GetComponent<Text> ();
		attackAngle = transform.Find ("Panel/Attack Angle").GetComponent<Image> ();
		attackRange = transform.Find ("Panel/Attack Range").GetComponent<Text> ();

	}

	void LateUpdate ()
	{
		float value = cam.GetZoom ();
		float newScale = Mathf.Lerp (0.25f, 0.05f, value);
		transform.localScale = new Vector3 (newScale, newScale, newScale);
		float rotY = unit? cam.GetRotation () - unit.transform.localEulerAngles.y : cam.GetRotation ();
		float rotX = Mathf.LerpAngle (90, 25, value);
		transform.localEulerAngles = new Vector3 (rotX, rotY, transform.eulerAngles.z);
	}

}