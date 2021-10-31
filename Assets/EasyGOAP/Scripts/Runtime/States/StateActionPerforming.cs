using AillieoUtils.FSM;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public class StateActionPerforming : IState
    {
        public readonly Agent agent;

        public StateActionPerforming(Agent agent)
        {
            this.agent = agent;
        }

        public void OnEnter(StateMachine stateMachine)
        {
            IAction action = agent.GetCurAction();

            if (action == null)
            {
                stateMachine.SetInt(InternalKeys.actionResult, (int)ActionResult.Failed);
                return;
            }

            action.OnBeginExecute(agent);
        }

        public void OnExit(StateMachine stateMachine)
        {
            IAction action = agent.GetCurAction();

            if (action == null)
            {
                return;
            }

            ActionResult result = (ActionResult)stateMachine.GetInt(InternalKeys.actionResult);
            action.OnEndExecute(agent, result);
        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {
            IAction action = agent.GetCurAction();

            if (action == null)
            {
                stateMachine.SetInt(InternalKeys.actionResult, (int)ActionResult.Failed);
                return;
            }

            ActionResult result = action.Execute(agent, deltaTime);

            if (result != ActionResult.Unfinished)
            {
                // 任务完成了
                //Debug.Log("finished ...");
            }
            stateMachine.SetInt(InternalKeys.actionResult, (int)result);
        }
    }
}
