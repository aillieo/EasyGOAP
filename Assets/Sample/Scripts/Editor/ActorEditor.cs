using UnityEditor;
using UnityEngine;

namespace Sample
{
    [CustomEditor(typeof(Actor))]
    public class ActorEditor : Editor
    {
        private void OnEnable()
        {
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying)
            {
                EditorGUILayout.BeginVertical("box");

                Actor actor = target as Actor;
                if (actor == null)
                {
                    return;
                }

                EditorGUILayout.LabelField($"{actor.actorName}");
                //EditorGUILayout.LabelField($"{actor.stateMachine.GetCurrentState()}", new GUIStyle("label") { wordWrap = true });

                EditorGUILayout.EndVertical();
            }
        }
    }
}
