using AillieoUtils.FSM;

namespace AillieoUtils.EasyGOAP
{
    public class StateFindingNextAction : IState
    {
        public readonly Agent agent;

        public StateFindingNextAction(Agent agent)
        {
            this.agent = agent;
        }

        public void OnEnter(StateMachine stateMachine)
        {
            agent.NextAction();
            stateMachine.SetInt(InternalKeys.actionResult, (int)ActionResult.Unfinished);
        }

        public void OnExit(StateMachine stateMachine)
        {
        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {
        }
    }
}
