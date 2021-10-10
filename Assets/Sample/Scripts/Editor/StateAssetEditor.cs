using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Sample
{
    [CustomEditor(typeof(StateAsset))]
    public class StateAssetEditor : Editor
    {
        ReorderableList entryList;

        private void OnEnable()
        {
            SerializedProperty entries = serializedObject.FindProperty("entries");
            entryList = new ReorderableList(this.serializedObject, entries);
            entryList.drawHeaderCallback += rect => GUI.Label(rect, "State Entries:");
            entryList.elementHeightCallback += index => EditorGUIUtility.singleLineHeight;
            entryList.drawElementCallback += (rect, index, isActive, isFocused) => DrawOneEntry(entries, rect, index, isActive, isFocused);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            entryList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawOneEntry(SerializedProperty serializedProperty, Rect rect, int index, bool isActive, bool isFocused)
        {
            float splitWidth = 0.05f;
            float itemWidth = (1 - splitWidth) / 2;
            Rect left = rect;
            left.width = rect.width * itemWidth;
            Rect middle = rect;
            middle.x = left.x + left.width;
            middle.width = rect.width * splitWidth;
            Rect right = rect;
            right.x = middle.x + middle.width;
            right.width = rect.width * itemWidth;

            var element = serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(left, element.FindPropertyRelative("key"), GUIContent.none);
            EditorGUI.LabelField(middle, "");
            EditorGUI.PropertyField(right, element.FindPropertyRelative("value"), GUIContent.none);
        }
    }
}
