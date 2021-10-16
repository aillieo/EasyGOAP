using AillieoUtils.FSM;
using System.Collections;
using System.Collections.Generic;

namespace Sample
{
    public class S_Chopping : IState
    {
        private readonly string itemType;

        public S_Chopping(string itemType)
        {
            this.itemType = itemType;
        }

        public void OnEnter(StateMachine stateMachine)
        {

        }

        public void OnExit(StateMachine stateMachine)
        {

        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {

        }
    }
}
