using System.Collections;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class BaseItem : ScriptableObject
{

    public string itemName = "Item Name Here";

    #region Base Stats

    public float plusStrength;
    public float plusAgility;
    public float plusIntelligence;
    public float plusHealth;
    public float plusAP;
    public float plusMana;
    public float plusMeleeDmg;
    public float plusRangedDmg;
    public float plusMagicDmg;
    public float plusMeleeDef;
    public float plusRangedDef;
    public float plusMagicDef;
    public float plusMoveSpeed;
    public float plusAttackSpeed;
    public float plusEvasion;

    #endregion

    #region Stat Multipliers

    public float multStrength;
    public float multAgility;
    public float multIntelligence;
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

    public virtual void Equip (HexUnit unit)
    {
        unit.plusStrength += plusStrength;
        unit.plusAgility += plusAgility;
        unit.plusIntelligence += plusIntelligence;
        unit.plusHealth += plusHealth;
        unit.plusAP += plusAP;
        unit.plusMana += plusMana;
        unit.plusMeleeDmg += plusMeleeDmg;
        unit.plusRangedDmg += plusRangedDmg;
        unit.plusMagicDmg += plusMagicDmg;
        unit.plusMeleeDef += plusMeleeDef;
        unit.plusRangedDef += plusRangedDef;
        unit.plusMagicDef += plusMagicDef;
        unit.plusMoveSpeed += plusMoveSpeed;
        unit.plusAttackSpeed += plusAttackSpeed;
        unit.plusEvasion += plusEvasion;

        unit.multStrength *= multStrength;
        unit.multAgility *= multAgility;
        unit.multIntelligence *= multIntelligence;
        unit.multHealth *= multHealth;
        unit.multAP *= multAP;
        unit.multMana *= multMana;
        unit.multMeleeDmg *= multMeleeDmg;
        unit.multRangedDmg *= multRangedDmg;
        unit.multMagicDmg *= multMagicDmg;
        unit.multMeleeDef *= multMeleeDef;
        unit.multRangedDef *= multRangedDef;
        unit.multMagicDef *= multMagicDef;
        unit.multMoveSpeed *= multMoveSpeed;
        unit.multAttackSpeed *= multAttackSpeed;
        unit.multEvasion *= multEvasion;
    }

    public virtual void UnEquip (HexUnit unit)
    {
        unit.plusStrength -= plusStrength;
        unit.plusAgility -= plusAgility;
        unit.plusIntelligence -= plusIntelligence;
        unit.plusHealth -= plusHealth;
        unit.plusAP -= plusAP;
        unit.plusMana -= plusMana;
        unit.plusMeleeDmg -= plusMeleeDmg;
        unit.plusRangedDmg -= plusRangedDmg;
        unit.plusMagicDmg -= plusMagicDmg;
        unit.plusMeleeDef -= plusMeleeDef;
        unit.plusRangedDef -= plusRangedDef;
        unit.plusMagicDef -= plusMagicDef;
        unit.plusMoveSpeed -= plusMoveSpeed;
        unit.plusAttackSpeed -= plusAttackSpeed;
        unit.plusEvasion -= plusEvasion;

        unit.multStrength /= multStrength;
        unit.multAgility /= multAgility;
        unit.multIntelligence /= multIntelligence;
        unit.multHealth /= multHealth;
        unit.multAP /= multAP;
        unit.multMana /= multMana;
        unit.multMeleeDmg /= multMeleeDmg;
        unit.multRangedDmg /= multRangedDmg;
        unit.multMagicDmg /= multMagicDmg;
        unit.multMeleeDef /= multMeleeDef;
        unit.multRangedDef /= multRangedDef;
        unit.multMagicDef /= multMagicDef;
        unit.multMoveSpeed /= multMoveSpeed;
        unit.multAttackSpeed /= multAttackSpeed;
        unit.multEvasion /= multEvasion;
    }
}

public class HeadPiece : BaseItem
{

}
public class MakeHeadPieceObject
{
    [MenuItem ("Grid Project/Objects/New Head Piece")]
    public static void Create ()
    {
        HeadPiece asset = ScriptableObject.CreateInstance<HeadPiece> ();
        AssetDatabase.CreateAsset (asset, "Assets/Data/Items/HeadPieces/NewHelmet.asset");
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }

}
public class ChestPiece : BaseItem
{

}
public class MakeChestPieceObject
{
    [MenuItem ("Grid Project/Objects/New Chest Piece")]
    public static void Create ()
    {
        ChestPiece asset = ScriptableObject.CreateInstance<ChestPiece> ();
        AssetDatabase.CreateAsset (asset, "Assets/Data/Items/ChestPieces/NewShirt.asset");
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }

}
public class ArmPiece : BaseItem
{

}
public class MakeArmPieceObject
{
    [MenuItem ("Grid Project/Objects/New Arm Piece")]
    public static void Create ()
    {
        ArmPiece asset = ScriptableObject.CreateInstance<ArmPiece> ();
        AssetDatabase.CreateAsset (asset, "Assets/Data/Items/ArmPieces/NewGloves.asset");
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }

}
public class LegsPiece : BaseItem
{

}
public class MakeLegsPieceObject
{
    [MenuItem ("Grid Project/Objects/New Legs Piece")]
    public static void Create ()
    {
        LegsPiece asset = ScriptableObject.CreateInstance<LegsPiece> ();
        AssetDatabase.CreateAsset (asset, "Assets/Data/Items/LegsPieces/NewPants.asset");
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }

}
public class FeetPiece : BaseItem
{

}
public class MakeFeetPieceObject
{
    [MenuItem ("Grid Project/Objects/New Feet Piece")]
    public static void Create ()
    {
        FeetPiece asset = ScriptableObject.CreateInstance<FeetPiece> ();
        AssetDatabase.CreateAsset (asset, "Assets/Data/Items/FeetPieces/NewShoes.asset");
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }

}
public class Weapon : BaseItem
{
    public HexAttackType weaponType;
    public HexAngleType attackAngle;
    public int attackRange;

    public override void Equip (HexUnit unit)
    {
        base.Equip (unit);

        unit.attackType = weaponType;
        unit.attackRange = attackRange;
        unit.attackAngle = attackAngle;
    }

    public override void UnEquip (HexUnit unit)
    {
        base.UnEquip (unit);

        unit.attackType = HexAttackType.None;
        unit.attackRange = 0;
        unit.attackAngle = HexAngleType.Regular;
    }
}
public class MakeWeaponObject
{
    [MenuItem ("Grid Project/Objects/New Weapon")]
    public static void Create ()
    {
        Weapon asset = ScriptableObject.CreateInstance<Weapon> ();
        AssetDatabase.CreateAsset (asset, "Assets/Data/Items/Weapon/NewWeapon.asset");
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }

}