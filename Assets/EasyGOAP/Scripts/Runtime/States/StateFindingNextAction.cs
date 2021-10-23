using AillieoUtils.FSM;
using UnityEngine;

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

            UnityEngine.Debug.LogError($"Enter find");
        }

        public void OnExit(StateMachine stateMachine)
        {
            UnityEngine.Debug.LogError($"Exit find");
        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {
        }
    }
}
