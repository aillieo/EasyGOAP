namespace AillieoUtils.FSM
{
    public interface IState
    {
        void OnEnter(StateMachine stateMachine);

        void OnExit(StateMachine stateMachine);

        void OnUpdate(StateMachine stateMachine, float deltaTime);
    }
}
