using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (BaseItem), true)]
public class ItemInspector : Editor
{
	SerializedProperty itemName;
	SerializedProperty plusStrength,
	plusAgility,
	plusIntelligence,
	plusHealth,
	plusAP,
	plusMana,
	plusMeleeDmg,
	plusRangedDmg,
	plusMagicDmg,
	plusMeleeDef,
	plusRangedDef,
	plusMagicDef,
	plusMoveSpeed,
	plusAttackSpeed,
	plusEvasion;
	SerializedProperty multStrength,
	multAgility,
	multIntelligence,
	multHealth,
	multAP,
	multMana,
	multMeleeDmg,
	multRangedDmg,
	multMagicDmg,
	multMeleeDef,
	multRangedDef,
	multMagicDef,
	multMoveSpeed,
	multAttackSpeed,
	multEvasion;

	Vector2 str;
	void OnEnable ()
	{
		itemName = serializedObject.FindProperty ("itemName");

		plusStrength = serializedObject.FindProperty ("plusStrength");
		plusAgility = serializedObject.FindProperty ("plusAgility");
		plusIntelligence = serializedObject.FindProperty ("plusIntelligence");
		plusHealth = serializedObject.FindProperty ("plusHealth");
		plusAP = serializedObject.FindProperty ("plusAP");
		plusMana = serializedObject.FindProperty ("plusMana");
		plusMeleeDmg = serializedObject.FindProperty ("plusMeleeDmg");
		plusRangedDmg = serializedObject.FindProperty ("plusRangedDmg");
		plusMagicDmg = serializedObject.FindProperty ("plusMagicDmg");
		plusMeleeDef = serializedObject.FindProperty ("plusMeleeDef");
		plusRangedDef = serializedObject.FindProperty ("plusRangedDef");
		plusMagicDef = serializedObject.FindProperty ("plusMagicDef");
		plusMoveSpeed = serializedObject.FindProperty ("plusMoveSpeed");
		plusAttackSpeed = serializedObject.FindProperty ("plusAttackSpeed");
		plusEvasion = serializedObject.FindProperty ("plusEvasion");

		multStrength = serializedObject.FindProperty ("multStrength");
		multAgility = serializedObject.FindProperty ("multAgility");
		multIntelligence = serializedObject.FindProperty ("multIntelligence");
		multHealth = serializedObject.FindProperty ("multHealth");
		multAP = serializedObject.FindProperty ("multAP");
		multMana = serializedObject.FindProperty ("multMana");
		multMeleeDmg = serializedObject.FindProperty ("multMeleeDmg");
		multRangedDmg = serializedObject.FindProperty ("multRangedDmg");
		multMagicDmg = serializedObject.FindProperty ("multMagicDmg");
		multMeleeDef = serializedObject.FindProperty ("multMeleeDef");
		multRangedDef = serializedObject.FindProperty ("multRangedDef");
		multMagicDef = serializedObject.FindProperty ("multMagicDef");
		multMoveSpeed = serializedObject.FindProperty ("multMoveSpeed");
		multAttackSpeed = serializedObject.FindProperty ("multAttackSpeed");
		multEvasion = serializedObject.FindProperty ("multEvasion");

	}
	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();

		EditorGUILayout.DelayedTextField (itemName, GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		// Headers
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Stat Modifier", GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.LabelField ("Additive", GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.LabelField ("Multiplier", GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.Space ();

		// Strength
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusStrength, new GUIContent ("Strenght"));
		EditorGUILayout.DelayedFloatField (multStrength, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Agility
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusAgility, new GUIContent ("Agility"));
		EditorGUILayout.DelayedFloatField (multAgility, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Intelligence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusIntelligence, new GUIContent ("Intelligence"));
		EditorGUILayout.DelayedFloatField (multIntelligence, GUIContent.none);
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.Space ();

		// Health
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusHealth, new GUIContent ("Health"));
		EditorGUILayout.DelayedFloatField (multHealth, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// AP
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusAP, new GUIContent ("Ability Points"));
		EditorGUILayout.DelayedFloatField (multAP, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Mana
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusMana, new GUIContent ("Mana"));
		EditorGUILayout.DelayedFloatField (multMana, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Melee Damage
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusMeleeDmg, new GUIContent ("Melee Damage"));
		EditorGUILayout.DelayedFloatField (multMeleeDmg, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Ranged Damage
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusRangedDmg, new GUIContent ("Ranged Damage"));
		EditorGUILayout.DelayedFloatField (multRangedDmg, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Magic Damage
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusMagicDmg, new GUIContent ("Magic Damage"));
		EditorGUILayout.DelayedFloatField (multMagicDmg, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Melee Defence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusMeleeDef, new GUIContent ("Melee Defence"));
		EditorGUILayout.DelayedFloatField (multMeleeDef, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Ranged Defence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusRangedDef, new GUIContent ("Ranged Defence"));
		EditorGUILayout.DelayedFloatField (multRangedDef, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Magic Defence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusMagicDef, new GUIContent ("Magic Defence"));
		EditorGUILayout.DelayedFloatField (multMagicDef, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Move Speed
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusMoveSpeed, new GUIContent ("Move Speed"));
		EditorGUILayout.DelayedFloatField (multMoveSpeed, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Attack Speed
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusAttackSpeed, new GUIContent ("Attack Speed"));
		EditorGUILayout.DelayedFloatField (multAttackSpeed, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		// Evasion
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (plusEvasion, new GUIContent ("Evasion"));
		EditorGUILayout.DelayedFloatField (multEvasion, GUIContent.none);
		EditorGUILayout.EndHorizontal ();

		serializedObject.ApplyModifiedProperties ();
	}
}