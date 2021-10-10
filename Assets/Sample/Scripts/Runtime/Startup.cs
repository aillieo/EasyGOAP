using System;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.GOAP;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    //[DefaultExecutionOrder(-1)]
    public class Startup : MonoBehaviour
    {
        [SerializeField]
        private StateAsset stateAsset;
        [SerializeField]
        private Actor actorTemplate;

        private void Start()
        {
            if (stateAsset != null)
            {
                GameManager.Instance.worldStates.Update(stateAsset);
            }

            foreach (var i in Enumerable.Range(0, 2))
            {
                Actor a = GameObject.Instantiate(actorTemplate);
                //a.transform.SetParent();
                GameManager.Instance.actors.Add(a);
            }
        }
    }
}
