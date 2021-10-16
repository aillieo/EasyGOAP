using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.PropLogics;
using UnityEditor;
using UnityEngine;

namespace AillieoUtils.EasyGOAP.Editor
{
    public class GlobalDebuggerWindow : EditorWindow
    {
        private class StateRecordInfo
        {
            public bool expand = true;
        }

        private Dictionary<string, StateRecordInfo> stateRecords = new Dictionary<string, StateRecordInfo>();
        private string filterStr;
        private Vector2 scrollPos;

        [MenuItem("AillieoUtils/EasyGOAP/GlobalDebuggerWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<GlobalDebuggerWindow>(nameof(GlobalDebuggerWindow));
            window.Show();
            window.autoRepaintOnSceneChange = true;
        }

        private void OnGUI()
        {
            filterStr = EditorGUILayout.TextField("Filter:", filterStr);

            var states = GlobalDebugger.states;

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            foreach (var s in states)
            {
                OnGUIFor(s);
            }

            EditorGUILayout.EndScrollView();
        }

        private void OnGUIFor(GlobalDebugger.StateInfo stateInfo)
        {
            //EditorGUILayout.LabelField(stateInfo.name);
            if (!stateRecords.TryGetValue(stateInfo.name, out StateRecordInfo stateRecord))
            {
                stateRecord = new StateRecordInfo();
                stateRecords.Add(stateInfo.name, stateRecord);
            }

            string title = stateRecord.expand ? stateInfo.name : $"{stateInfo.name}({stateInfo.state.properties.Count()})";
            stateRecord.expand = EditorGUILayout.Foldout(stateRecord.expand, title);
            if (stateRecord.expand)
            {
                EditorGUI.indentLevel++;
                IEnumerable<PropertyPair> properties = stateInfo.state.properties;
                if (!string.IsNullOrEmpty(filterStr))
                {
                    properties = properties.Where(p => p.key.Contains(filterStr));
                }

                foreach (var p in properties)
                {
                    EditorGUILayout.LabelField(p.ToString());
                }

                EditorGUI.indentLevel--;
            }
        }
    }
}
