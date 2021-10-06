using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.GOAP;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    [DefaultExecutionOrder(-1)]
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


        public readonly PropertyProvider worldStates = new PropertyProvider();
        public readonly List<Actor> actors = new List<Actor>();

        public IGraph<IAction> BuildLogicGraph()
        {
            throw new NotImplementedException();
        }

        private void Start()
        {
            foreach (var i in Enumerable.Range(0, 2))
            {

            }
        }

        private void Update()
        {

        }
    }
}
