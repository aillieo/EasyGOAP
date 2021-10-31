using System;
using AillieoUtils.FSM;
using AillieoUtils.PropLogics;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AillieoUtils.EasyGOAP
{
    public class Agent
    {
        private readonly StateMachine stateMachine;
        private readonly World belongingWorld;
        private readonly List<IAction> availableActions = new List<IAction>();
        private readonly Dictionary<Goal, float> availableGoals = new Dictionary<Goal, float>();

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
                Goal g = GetCurGoal();
                if (g == null)
                {
                    return null;
                }
                path = belongingWorld.FindPath(this, g, availableActions);
            }

            if (cursor == null)
            {
                cursor = path.GetEnumerator();
            }

            return cursor.Current;
        }

        internal bool NextAction()
        {
            if (path == null)
            {
                Goal g = GetCurGoal();
                if (g == null)
                {
                    return false;
                }
                path = belongingWorld.FindPath(this, g, availableActions);
            }

            if (cursor == null)
            {
                cursor = path.GetEnumerator();
            }

            bool hasNext = cursor.MoveNext();
            if (!hasNext)
            {
                ResetGoal();
            }

            return hasNext;
        }

        public World GetWorld()
        {
            return belongingWorld;
        }

        public StateMachine GetStateMachine()
        {
            return stateMachine;
        }

        public void AddGoal(Goal goal)
        {
            AddOrUpdateGoal(goal, 1);
        }

        public void AddOrUpdateGoal(Goal goal, float weight)
        {
            availableGoals[goal] = weight;
            if (curGoal != null && availableGoals[curGoal] < weight)
            {
                ResetGoal();
            }
        }

        public IEnumerable<KeyValuePair<Goal, float>> GetAllGoals()
        {
            return availableGoals;
        }

        public bool RemoveGoal(Goal goal)
        {
            if (goal == curGoal)
            {
                ResetGoal();
            }

            return availableGoals.Remove(goal);
        }

        public int RemoveGoal(Func<Goal, bool> filter)
        {
            List<Goal> toRemove = new List<Goal>();
            foreach (var pair in availableGoals)
            {
                if (filter(pair.Key))
                {
                    toRemove.Add(pair.Key);
                }
            }

            int count = 0;
            foreach (var goal in toRemove)
            {
                if (RemoveGoal(goal))
                {
                    count++;
                }
            }

            return count;
        }

        public Goal GetCurGoal()
        {
            if (curGoal == null)
            {
                var notReached = availableGoals.Where(g => !g.Key.Reached(belongingWorld.GetWorldState()));
                if (!notReached.Any())
                {
                    return null;
                }

                curGoal = notReached.OrderByDescending(g => g.Value).First().Key;
            }

            return curGoal;
        }

        internal void ResetGoal()
        {
            curGoal = null;
            path = null;
            cursor = null;
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
