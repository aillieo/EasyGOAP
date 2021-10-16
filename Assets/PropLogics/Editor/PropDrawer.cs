using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AillieoUtils.PropLogics;
using UnityEditor;
using UnityEngine;

namespace AillieoUtils.EasyGOAP.Editor
{
    [CustomPropertyDrawer(typeof(Property))]
    public class PropDrawer : PropertyDrawer
    {
        private static PropertyInfo indentProperty = typeof(EditorGUI).GetProperty("indent", BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Static);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position = EditorGUI.PrefixLabel(position, label);
            float indent = (float)indentProperty.GetValue(null);

            position.x -= indent;
            position.width += indent;
            position.width += indent;

            Rect left = position;
            left.width = position.width / 2;

            Rect right = left;
            right.x += left.width;
            right.x -= indent;

            SerializedProperty type = property.FindPropertyRelative("type");
            SerializedProperty value = property.FindPropertyRelative("value");
            SerializedProperty intValue = value.FindPropertyRelative("intValue");

            EditorGUI.PropertyField(left, type, GUIContent.none);

            switch ((Property.ValueType)type.enumValueIndex)
            {
            case Property.ValueType.Invalid:
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUI.TextField(right, $"{intValue.intValue:X8}");
                }

                break;
            case Property.ValueType.Int:
                intValue.intValue = EditorGUI.IntField(right, GUIContent.none, intValue.intValue);
                break;
            case Property.ValueType.Float:
                float oldFloat = (float)(Property)intValue.intValue;
                float newFloat = EditorGUI.FloatField(right, GUIContent.none, oldFloat);
                intValue.intValue = (int)(Property)newFloat;
                break;
            case Property.ValueType.Bool:
                bool oldBool = (bool)(Property)intValue.intValue;
                bool newBool = EditorGUI.Toggle(right, GUIContent.none, oldBool);
                intValue.intValue = (int)(Property)newBool;
                break;
            }
        }
    }
}
