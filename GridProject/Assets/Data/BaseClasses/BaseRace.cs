using System.Collections;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class BaseRace : ScriptableObject
{

	public string raceName = "Race Name Here";

	#region Base Stats

	public float baseStrength;
	public float baseAgility;
	public float baseIntelligence;
	public float baseHealth;
	public float baseAP;
	public float baseMana;
	public float baseMeleeDmg;
	public float baseRangedDmg;
	public float baseMagicDmg;
	public float baseMeleeDef;
	public float baseRangedDef;
	public float baseMagicDef;
	public float baseMoveSpeed;
	public float baseAttackSpeed;
	public float baseEvasion;

	#endregion

	#region Stat Multipliers

	public float multHealth;
	public float multAP;
	public float multMana;
	public float multMeleeDmg;
	public float multRangedDmg;
	public float multMagicDmg;
	public float multMeleeDef;
	public float multRangedDef;
	public float multMagicDef;
	public float multMoveSpeed;
	public float multAttackSpeed;
	public float multEvasion;

	#endregion
}
public class MakeRaceObject
{
	[MenuItem ("Grid Project/World/New Race")]
	public static void Create ()
	{
		BaseRace asset = ScriptableObject.CreateInstance<BaseRace> ();
		AssetDatabase.CreateAsset (asset, "Assets/Data/Races/NewRace.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}

}