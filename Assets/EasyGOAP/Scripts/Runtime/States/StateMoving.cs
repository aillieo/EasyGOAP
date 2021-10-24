using AillieoUtils.EasyGOAP;
using AillieoUtils.FSM;
using System;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public class StateMoving : IState
    {
        public readonly Agent agent;
        public string positionName;

        public StateMoving(Agent agent)
        {
            this.agent = agent;
        }

        public void OnEnter(StateMachine stateMachine)
        {
            Debug.LogError("Enter moving");
        }

        public void OnExit(StateMachine stateMachine)
        {
            Debug.LogError("Exit moving");
        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {
            Vector2 targetPos = stateMachine.GetVector2(InternalKeys.targetPosition);
            Vector2 newPos = Vector2.MoveTowards(agent.GetPosition(), targetPos, agent.moveSpeed * deltaTime);
            agent.SetPosition(newPos);
            stateMachine.SetFloat(InternalKeys.distanceToTarget, Vector2.Distance(newPos, targetPos));
        }
    }
}
