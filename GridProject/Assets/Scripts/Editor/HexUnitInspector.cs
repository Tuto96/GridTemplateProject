using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(HexUnit))]
public class HexUnitInspector : Editor
{
	private int portraitSize = 128;
	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();
		EditorGUILayout.ObjectField (
			serializedObject.FindProperty ("portrait"),
			typeof (Sprite), new GUIContent ("Portrait"),
			GUILayout.MinHeight (48), GUILayout.MinWidth (48),
			GUILayout.Height (portraitSize), GUILayout.Width (portraitSize)
			//GUILayout.ExpandHeight(true)
			, GUILayout.ExpandWidth (true)
		);
		//EditorList.Show(serializedObject.FindProperty("myStats.stats"));
		serializedObject.ApplyModifiedProperties ();
	}
}