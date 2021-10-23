using System.Collections.Generic;
using AillieoUtils.EasyGOAP;
using UnityEngine;

namespace Sample
{
    //[DefaultExecutionOrder(-1)]
    public class GameManager : MonoBehaviour
    {
        private static GameManager ins;

        public static GameManager Instance
        {
            get
            {
                if (ins == null)
                {
                    GameObject go = new GameObject("GameManager");
                    ins = go.AddComponent<GameManager>();
                    GameObject.DontDestroyOnLoad(go);
                }

                return ins;
            }
        }

        private void Awake()
        {
            if (ins != null && ins != this)
            {
                Destroy(this);
            }
        }

        public readonly World world = new World();
        private readonly Planner planner = new Planner();
        private readonly Dictionary<int, SceneObj> objMappings = new Dictionary<int, SceneObj>();
        private readonly Dictionary<string, int> tables = new Dictionary<string, int>();

        public void RecordSceneObj(int id, SceneObj sceneObj)
        {
            objMappings[id] = sceneObj;
            if (sceneObj is Table t)
            {
                tables[StateHelper.HashItemKey(t.itemName, t.itemStatus)] = id;
            }
        }

        public int GetTableForItem(string tableKey)
        {
            if (tables.TryGetValue(tableKey, out int tableObjId))
            {
                return tableObjId;
            }
            return 0;
        }

        public SceneObj GetSceneObj(int id)
        {
            if(objMappings.TryGetValue(id, out SceneObj obj))
            {
                return obj;
            }
            return null;
        }

        public IEnumerable<IAction> Find(IEnumerable<IAction> availableActions)
        {
            //return planner.Find(worldStates, availableActions);

            return new IAction[]
            {
                new A_BeefChopping(),
                new A_BeefCooking(),
                new A_TomatoChopping(),
                new A_BurgerAssemblingTomato(),
                new A_BurgerPlating(),
            };
        }
    }
}
