using System;
using AillieoUtils.FSM;
using AillieoUtils.PropLogics;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public class Agent
    {
        private readonly StateMachine stateMachine;
        private readonly World belongingWorld;
        private readonly List<IAction> availableActions = new List<IAction>();

        private Vector2 position;
        public float moveSpeed;
        private Goal curGoal;

        private IEnumerable<IAction> path;
        private IEnumerator<IAction> cursor;

        internal Agent(World world)
        {
            belongingWorld = world;

            FSMBuilder builder = new FSMBuilder();
            builder.SetDefaultState(new DefaultState());

            StateFindingNextAction stateFindingNextAction = new StateFindingNextAction(this);
            builder.AddState(stateFindingNextAction);
            builder.CreateTransitionFromAnyState(stateFindingNextAction).AddCondition(new Condition(InternalKeys.actionResult, ConditionMode.NotEqual, (int)ActionResult.Unfinished));

            StateMoving stateMoving = new StateMoving(this);
            builder.AddState(stateMoving);
            builder.CreateTransitionFromAnyState(stateMoving).AddCondition(new Condition(InternalKeys.distanceToTarget, ConditionMode.Greater, 0f));

            StateActionPerforming stateActionPerforming = new StateActionPerforming(this);
            builder.AddState(stateActionPerforming);
            builder.CreateTransition(stateMoving, stateActionPerforming).AddCondition(new Condition(InternalKeys.distanceToTarget, ConditionMode.LessEqual, 0f));
            builder.CreateTransition(stateFindingNextAction, stateActionPerforming).AddCondition(new Condition(InternalKeys.actionResult, ConditionMode.Equal, (int)ActionResult.Unfinished));

            stateMachine = builder.ToStateMachine();

            GlobalDebugger.RecordState($"Agent{GetHashCode()}", stateMachine.GetAssociatedProperties());
        }

        public void AddAvailableAction(IAction action)
        {
            availableActions.Add(action);
        }

        public void AddAvailableActions(IEnumerable<IAction> actions)
        {
            availableActions.AddRange(actions);
        }

        public bool RemoveAction(IAction action)
        {
            return availableActions.Remove(action);
        }

        public int RemoveAllActionsForType(Type type)
        {
            return availableActions.RemoveAll(a => a.GetType() == type);
        }

        public void Init()
        {
            stateMachine.Init();
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public IAction GetCurAction()
        {
            if (path == null)
            {
                path = belongingWorld.FindPath(this,curGoal, availableActions);
            }

            if (cursor == null)
            {
                cursor = path.GetEnumerator();
            }

            return cursor.Current;
        }

        public bool NextAction()
        {
            if (path == null)
            {
                path = belongingWorld.FindPath(this, curGoal, availableActions);
            }

            if (cursor == null)
            {
                cursor = path.GetEnumerator();
            }

            return cursor.MoveNext();
        }

        public void Replan()
        {

        }

        public World GetWorld()
        {
            return belongingWorld;
        }

        public StateMachine GetStateMachine()
        {
            return stateMachine;
        }

        public void SetGoal(Goal goal)
        {
            curGoal = goal;
        }

        public Goal GetCurGoal()
        {
            return curGoal;
        }

        public void Update(float deltaTime)
        {
            stateMachine.Update(deltaTime);
        }

        public void CleanUp()
        {
            stateMachine.CleanUp();
        }
    }
}
