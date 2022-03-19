using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Data;

[CustomEditor(typeof(Potal))]
public class PotalEditor : Editor
{
    public Potal selected;

    private void OnEnable()
    {
        if (AssetDatabase.Contains(target)) {
            selected = null;
        }
        else {
            selected = (Potal)target;
        }
    }

    public override void OnInspectorGUI()
    {
        if (selected == null)
            return;

        GUI.color = Color.white;

        selected.potalTriggerType = (PotalTriggerType)EditorGUILayout.EnumPopup("Potal Trigger Type", selected.potalTriggerType);
        selected.potalType = (PotalType)EditorGUILayout.EnumPopup("Potal Type", selected.potalType);
        if (selected.potalType == PotalType.StageChange) {
            selected.changeStageName = EditorGUILayout.TextField("Change Stage Name", selected.changeStageName);
        }
        else if(selected.potalType == PotalType.Teleport) {
            selected.teleportPostion = EditorGUILayout.Vector3Field("Teleport Postion", selected.teleportPostion);
            selected.teleportViewRotation = EditorGUILayout.Vector2Field("Teleport View", selected.teleportViewRotation);
        }

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
}
