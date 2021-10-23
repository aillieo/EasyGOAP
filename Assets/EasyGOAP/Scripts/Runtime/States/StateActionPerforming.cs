using AillieoUtils.FSM;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public class StateActionPerforming : IState
    {
        private ActionResult result;
        public readonly Agent agent;

        public StateActionPerforming(Agent agent)
        {
            this.agent = agent;
        }

        public void OnEnter(StateMachine stateMachine)
        {
            IAction action = agent.GetCurAction();

            UnityEngine.Debug.LogError($"Enter action  {action}");

            if (action == null)
            {
                stateMachine.SetInt(InternalKeys.actionResult, (int)ActionResult.Failed);
                return;
            }

            action.OnBeginExecute();
        }

        public void OnExit(StateMachine stateMachine)
        {
            IAction action = agent.GetCurAction();

            if (action == null)
            {
                return;
            }

            action.OnEndExecute(result);

            UnityEngine.Debug.LogError($"Exit action  {action}");
        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {
            IAction action = agent.GetCurAction();

            UnityEngine.Debug.LogError($"Update action  {action}");

            if (action == null)
            {
                stateMachine.SetInt(InternalKeys.actionResult, (int)ActionResult.Failed);
                return;
            }

            result = action.Execute(deltaTime);

            if (result != ActionResult.Unfinished)
            {
                // 任务完成了
                Debug.LogError("finished ...");
            }
            stateMachine.SetInt(InternalKeys.actionResult, (int)result);
        }
    }
}
