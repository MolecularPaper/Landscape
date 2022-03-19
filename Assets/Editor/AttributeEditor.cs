using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityEngine
{
    #region ShowOnly

    [CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
    public class ShowOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            string value = "[Not Supported]";
            switch (property.propertyType) {
                case SerializedPropertyType.Generic: break;
                case SerializedPropertyType.Integer: value = property.intValue.ToString(); break;
                case SerializedPropertyType.Boolean: value = property.boolValue.ToString(); break;
                case SerializedPropertyType.Float: value = property.floatValue.ToString(); break;
                case SerializedPropertyType.String: value = property.stringValue; break;
                default:
                    switch (property.propertyType) {
                        case SerializedPropertyType.Color:
                        case SerializedPropertyType.ObjectReference:
                        case SerializedPropertyType.LayerMask:
                        case SerializedPropertyType.Enum:
                        case SerializedPropertyType.Vector2:
                        case SerializedPropertyType.Vector3:
                        case SerializedPropertyType.Vector4:
                        case SerializedPropertyType.Rect:
                        case SerializedPropertyType.ArraySize:
                        case SerializedPropertyType.Character:
                        case SerializedPropertyType.AnimationCurve:
                        case SerializedPropertyType.Bounds:
                        case SerializedPropertyType.Gradient:
                        case SerializedPropertyType.Quaternion:
                        case SerializedPropertyType.ExposedReference:
                        case SerializedPropertyType.FixedBufferSize:
                        case SerializedPropertyType.Vector2Int:
                        case SerializedPropertyType.Vector3Int:
                        case SerializedPropertyType.RectInt:
                        case SerializedPropertyType.BoundsInt:
                        case SerializedPropertyType.ManagedReference:
                            Debug.LogWarning("ReadOnly를 사용해주세요.");
                            break;
                        default: break;
                    }
                    break;
            }
            EditorGUI.LabelField(position, label.text, value);
        }
    }
    #endregion
    #region ReadOnly
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
    #endregion
}