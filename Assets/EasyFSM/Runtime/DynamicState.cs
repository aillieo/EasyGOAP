using System;

namespace AillieoUtils.FSM
{
    public class DynamicState : IState
    {
        private Action<StateMachine> onEnter;
        private Action<StateMachine> onExit;
        private Action<StateMachine, float> onUpdate;

        public DynamicState(Action<StateMachine> onEnter, Action<StateMachine> onExit, Action<StateMachine, float> onUpdate)
        {
            this.onEnter = onEnter;
            this.onExit = onExit;
            this.onUpdate = onUpdate;
        }

        public void OnEnter(StateMachine stateMachine)
        {
            onEnter?.Invoke(stateMachine);
        }

        public void OnExit(StateMachine stateMachine)
        {
            onExit?.Invoke(stateMachine);
        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {
            onUpdate?.Invoke(stateMachine, deltaTime);
        }
    }
}
