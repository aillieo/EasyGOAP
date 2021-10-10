using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEditor;
using UnityEngine;

namespace AillieoUtils.GOAP.Editor
{
    [CustomPropertyDrawer(typeof(Property))]
    public class PropDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect left = position;
            left.width = position.width / 2;
            Rect right = position;
            right.x = position.x + left.width;
            right.width = position.width / 2;

            SerializedProperty type = property.FindPropertyRelative("type");
            SerializedProperty value = property.FindPropertyRelative("value");
            SerializedProperty intValue = value.FindPropertyRelative("intValue");

            EditorGUI.PropertyField(left, type, GUIContent.none);

            switch ((Property.ValueType)type.enumValueIndex)
            {
            case Property.ValueType.Invalid:
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
