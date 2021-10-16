using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

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
            foreach (var s in states)
            {
                OnGUIFor(s);
            }
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
                foreach (var p in stateInfo.state.properties.Where(p => p.key.Contains(filterStr)))
                {
                    EditorGUILayout.LabelField(p.ToString());
                }

                EditorGUI.indentLevel--;
            }
        }
    }
}
