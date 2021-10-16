using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.FSM;
using AillieoUtils.EasyGOAP;
using UnityEngine;
using System.Linq;

namespace Sample
{
    public class Actor : MonoBehaviour
    {
        public string actorName;
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

            Table table = GameManager.Instance.tables[0];
            S_Move moveForBeef = new S_Move(StateHelper.GetObjNameKey(table), this);

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
            if (agent.path == null)
            {
                agent.path = GameManager.Instance.Find(actions);
            }

            if (agent.curAction == null)
            {
                agent.curAction = agent.path.First();
            }

            stateMachine.Update(Time.deltaTime);

            IAction a = actions[UnityEngine.Random.Range(0, actions.Length)];
            if (GameManager.Instance.worldStates.MeetConditions(a.GetRequirements()))
            {
                GameManager.Instance.worldStates.ApplyModifications(a.GetEffects());
            }
        }
    }
}
