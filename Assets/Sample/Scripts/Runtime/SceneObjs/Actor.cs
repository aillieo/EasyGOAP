using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.FSM;
using AillieoUtils.EasyGOAP;
using UnityEngine;

namespace Sample
{
    public class Actor : MonoBehaviour
    {
        public string actorName;
        [Range(0.1f, 2f)]
        public float speed;

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

        private void Start()
        {
            FSMBuilder builder = new FSMBuilder();
            S_Move moveForBeef = new S_Move("Table_Beef_pos", this);

            builder.SetDefaultState(new DefaultState());
            builder.AddState(moveForBeef);

            //    .CreateTransition(move,)

            stateMachine = builder.ToStateMachine();
            stateMachine.Init();
        }

        private void OnDestroy()
        {
            stateMachine.CleanUp();
        }

        private void Update()
        {
            stateMachine.Update(Time.deltaTime);

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
