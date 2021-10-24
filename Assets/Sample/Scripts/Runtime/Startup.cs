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
                    GameManager.Instance.RecordTable(t.tableName, t);
                }
            }

            Actor[] actors = FindObjectsOfType<Actor>();
            if (actors != null)
            {
            }

            GlobalDebugger.RecordState("GlobalState", GameManager.Instance.world.GetWorldState());
        }
    }
}
