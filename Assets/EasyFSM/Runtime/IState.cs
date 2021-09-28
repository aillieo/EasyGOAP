namespace AillieoUtils.FSM
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
        void OnUpdate(float deltaTime);
    }
}
