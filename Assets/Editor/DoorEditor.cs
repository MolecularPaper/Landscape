using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Data;

[CustomEditor(typeof(Door)), CanEditMultipleObjects]
public class DoorEditor : Editor
{
    public Door selected;

    private void OnEnable()
    {
        if (AssetDatabase.Contains(target)) {
            selected = null;
        }
        else {
            selected = (Door)target;
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("doorData").FindPropertyRelative("canOpen"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("doorData").FindPropertyRelative("doorOpen"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("doorData").FindPropertyRelative("doorLocked"));
        if (selected.doorData.doorLocked) {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("doorKeyItemCode"));
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("sounds"));
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
}
