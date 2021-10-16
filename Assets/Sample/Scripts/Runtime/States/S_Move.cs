using AillieoUtils.FSM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class S_Move : IState
    {
        private readonly string positionName;
        private readonly Actor agent;
        public S_Move(string positionName, Actor agent)
        {
            this.positionName = positionName;
            this.agent = agent;
        }

        public void OnEnter(StateMachine stateMachine)
        {
            
        }

        public void OnExit(StateMachine stateMachine)
        {

        }

        public void OnUpdate(StateMachine stateMachine, float deltaTime)
        {
            Vector2 pos = StateHelper.GetPosition(GameManager.Instance.worldStates, positionName);
            Vector2 newPos = Vector2.MoveTowards(agent.transform.position.ToVector2(), pos, agent.speed * deltaTime);
            agent.transform.position = newPos.ToVector3();
            StateHelper.SaveObjPosition(GameManager.Instance.worldStates, agent);
        }
    }
}
