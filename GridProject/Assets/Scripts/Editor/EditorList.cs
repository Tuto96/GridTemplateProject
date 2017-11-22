using UnityEditor;
using UnityEngine;

public static class EditorList
{

	public static void Show (SerializedProperty list)
	{
		//EditorGUILayout.PropertyField(list);
		for (int i = 0; i < list.arraySize; i++)
		{
			EditorGUILayout.PropertyField (list.GetArrayElementAtIndex (i));
		}
	}
}