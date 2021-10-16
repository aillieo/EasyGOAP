using System;
using System.Collections.Generic;
using System.Linq;
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

        public readonly State worldStates = State.Create();
        public readonly List<Actor> actors = new List<Actor>();
        public readonly List<Table> tables = new List<Table>();

        public IGraph<IAction> BuildLogicGraph()
        {
            throw new NotImplementedException();
        }
    }
}
