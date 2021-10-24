using System;
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
        private readonly Dictionary<string, Table> tables = new Dictionary<string, Table>();

        public void RecordTable(string tableKey, Table table)
        {
            tables[tableKey] = table;
        }

        public Vector2 GetTablePosition(string tableKey)
        {
            if (tables.TryGetValue(tableKey, out Table table))
            {
                return table.transform.position.ToVector2();
            }

            throw new Exception($"no table  {tableKey}");
        }
    }
}
