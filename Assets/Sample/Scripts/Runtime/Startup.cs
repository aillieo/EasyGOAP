using System;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    //[DefaultExecutionOrder(-1)]
    public class Startup : MonoBehaviour
    {
        [SerializeField]
        private StateAsset stateAsset;

        private void Start()
        {
            if (stateAsset != null)
            {
                GameManager.Instance.worldStates.Update(stateAsset);
            }

            Table[] tables = FindObjectsOfType<Table>();
            if (tables != null)
            {
                GameManager.Instance.tables.AddRange(tables);
                foreach (var t in tables)
                {
                    StateHelper.SaveObjPosition(GameManager.Instance.worldStates, t);
                }
            }

            Actor[] actors = FindObjectsOfType<Actor>();
            if (actors != null)
            {
                GameManager.Instance.actors.AddRange(actors);
                foreach (var a in actors)
                {
                    StateHelper.SaveObjPosition(GameManager.Instance.worldStates, a);
                }
            }

            GlobalDebugger.RecordState("GlobalState", GameManager.Instance.worldStates);
        }
    }
}
