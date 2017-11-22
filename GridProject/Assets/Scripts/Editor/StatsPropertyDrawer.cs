using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer (typeof (Stat))]
public class StatsPropertyDrawer : PropertyDrawer
{
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty (position, label, property);
        Rect contentPosition = EditorGUI.PrefixLabel (position, new GUIContent (Enum.GetName (typeof (UnitStats), property.FindPropertyRelative ("myStat").intValue)));
        EditorGUI.indentLevel = 0;
        //GUI.Label(position, Enum.GetName(typeof(UnitStats), property.FindPropertyRelative("myStat").intValue ) );
        EditorGUI.PropertyField (contentPosition, property.FindPropertyRelative ("baseValue"), GUIContent.none);
        EditorGUI.EndProperty ();

    }
}