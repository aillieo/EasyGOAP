using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.FSM;
using AillieoUtils.GOAP;
using UnityEngine;

namespace Sample
{
    public class Actor : MonoBehaviour
    {
        private readonly Agent agent = new Agent();
        private StateMachine stateMachine;

        private static IAction[] actions = new IAction[]
        {
            new A_BeefChopping(),
            new A_BeefCooking(),
            new A_BurgerAssemblingCheese(),
            new A_BurgerAssemblingTomato(),
            new A_TomatoChopping(),
            new A_BurgerPlating(),
        };

        private void Update()
        {
            if (Time.frameCount % 10 != 0)
            {
                return;
            }

            IAction a = actions[UnityEngine.Random.Range(0, actions.Length)];
            if (GameManager.Instance.worldStates.MeetConditions(a.GetRequirements()))
            {
                Debug.LogError($"执行动作 {a}");
                GameManager.Instance.worldStates.ApplyModifications(a.GetEffects());
            }
        }
    }
}
