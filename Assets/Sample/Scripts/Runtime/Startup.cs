using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    [DefaultExecutionOrder(-1)]
    public class Startup : MonoBehaviour
    {
        [SerializeField]
        private StateAsset stateAsset;

        private void Start()
        {
            if (stateAsset != null)
            {
                GameManager.Instance.world.GetWorldState().Update(stateAsset);
            }

            Table[] tables = FindObjectsOfType<Table>();
            if (tables != null)
            {
                foreach (var t in tables)
                {
                    GameManager.Instance.RecordSceneObj(t.GetInstanceID(), t);
                    StateHelper.SaveObjPosition(GameManager.Instance.world.GetWorldState(), t);
                }
            }

            Actor[] actors = FindObjectsOfType<Actor>();
            if (actors != null)
            {
                foreach (var a in actors)
                {
                    GameManager.Instance.RecordSceneObj(a.GetInstanceID(), a);
                    StateHelper.SaveObjPosition(GameManager.Instance.world.GetWorldState(), a);
                }
            }

            if (actors != null && tables != null)
            {
                foreach(var a in actors)
                {
                    foreach(var t in tables)
                    {
                        StateHelper.SaveDistanceToTarget(GameManager.Instance.world.GetWorldState(), a, t);
                    }
                }
            }

            GlobalDebugger.RecordState("GlobalState", GameManager.Instance.world.GetWorldState());
        }
    }
}
