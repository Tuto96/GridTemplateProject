using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (BaseRace))]
public class RaceInspector : Editor
{
	SerializedProperty raceName;
	SerializedProperty baseStrength,
	baseAgility,
	baseIntelligence,
	baseHealth,
	baseAP,
	baseMana,
	baseMeleeDmg,
	baseRangedDmg,
	baseMagicDmg,
	baseMeleeDef,
	baseRangedDef,
	baseMagicDef,
	baseMoveSpeed,
	baseAttackSpeed,
	baseEvasion;
	SerializedProperty multHealth,
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
		raceName = serializedObject.FindProperty ("raceName");

		baseStrength = serializedObject.FindProperty ("baseStrength");
		baseAgility = serializedObject.FindProperty ("baseAgility");
		baseIntelligence = serializedObject.FindProperty ("baseIntelligence");
		baseHealth = serializedObject.FindProperty ("baseHealth");
		baseAP = serializedObject.FindProperty ("baseAP");
		baseMana = serializedObject.FindProperty ("baseMana");
		baseMeleeDmg = serializedObject.FindProperty ("baseMeleeDmg");
		baseRangedDmg = serializedObject.FindProperty ("baseRangedDmg");
		baseMagicDmg = serializedObject.FindProperty ("baseMagicDmg");
		baseMeleeDef = serializedObject.FindProperty ("baseMeleeDef");
		baseRangedDef = serializedObject.FindProperty ("baseRangedDef");
		baseMagicDef = serializedObject.FindProperty ("baseMagicDef");
		baseMoveSpeed = serializedObject.FindProperty ("baseMoveSpeed");
		baseAttackSpeed = serializedObject.FindProperty ("baseAttackSpeed");
		baseEvasion = serializedObject.FindProperty ("baseEvasion");

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

		EditorGUILayout.DelayedTextField (raceName, GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		// Headers
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Stat Name", GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.LabelField ("Base Value", GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.LabelField ("Multiplier", GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.Space ();

		// Strength
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseStrength, new GUIContent ("Strenght"), GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.EndHorizontal ();

		// Agility
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseAgility, new GUIContent ("Agility"), GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.EndHorizontal ();

		// Intelligence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseIntelligence, new GUIContent ("Intelligence"), GUILayout.MaxWidth (100), GUILayout.MinWidth (100), GUILayout.ExpandWidth (true));
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.Space ();

		// Health
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseHealth, new GUIContent ("Health"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multHealth, 0, 10, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// AP
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseAP, new GUIContent ("Ability Points"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multAP, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Mana
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseMana, new GUIContent ("Mana"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multMana, 0, 10, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Melee Damage
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseMeleeDmg, new GUIContent ("Melee Damage"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multMeleeDmg, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Ranged Damage
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseRangedDmg, new GUIContent ("Ranged Damage"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multRangedDmg, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Magic Damage
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseMagicDmg, new GUIContent ("Magic Damage"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multMagicDmg, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Melee Defence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseMeleeDef, new GUIContent ("Melee Defence"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multMeleeDef, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Ranged Defence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseRangedDef, new GUIContent ("Ranged Defence"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multRangedDef, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Magic Defence
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseMagicDef, new GUIContent ("Magic Defence"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multMagicDef, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Move Speed
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseMoveSpeed, new GUIContent ("Move Speed"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multMoveSpeed, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Attack Speed
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseAttackSpeed, new GUIContent ("Attack Speed"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multAttackSpeed, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		// Evasion
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.DelayedFloatField (baseEvasion, new GUIContent ("Evasion"), GUILayout.MaxWidth (80), GUILayout.MinWidth (80), GUILayout.ExpandWidth (true));
		EditorGUILayout.Slider (multEvasion, 0, 1, GUIContent.none, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();

		serializedObject.ApplyModifiedProperties ();
	}
}