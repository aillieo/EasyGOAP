using System.Reflection;
using AillieoUtils.PropLogics;
using UnityEditor;
using UnityEngine;

namespace AillieoUtils.EasyGOAP.Editor
{
    [CustomPropertyDrawer(typeof(PropertyPair))]
    public class PropPairDrawer : PropertyDrawer
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

            float interval = 2f;
            float itemWidth = (position.width - interval) / 2;
            Rect left = position;
            left.width = itemWidth;
            Rect right = left;
            right.x = left.x + left.width + interval;
            right.x -= indent;

            EditorGUI.PropertyField(left, property.FindPropertyRelative("key"), GUIContent.none);
            EditorGUI.PropertyField(right, property.FindPropertyRelative("value"), GUIContent.none);
        }
    }
}
