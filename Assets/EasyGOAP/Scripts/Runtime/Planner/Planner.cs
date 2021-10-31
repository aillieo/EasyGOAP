using System;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.PropLogics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AillieoUtils.EasyGOAP
{
    public class Planner
    {
        public IEnumerable<IAction> FindPath(Agent agent, WorldState initialState, Goal goal, IEnumerable<IAction> availableActions)
        {
            return BFS(agent, initialState, goal, availableActions);
        }

        private IEnumerable<IAction> BFS(Agent agent, WorldState initialState, Goal goal, IEnumerable<IAction> availableActions)
        {
            Queue<LogicNode> queue = new Queue<LogicNode>();
            List<LogicNode> processedNodes = new List<LogicNode>();
            LogicNode logicNode = LogicNode.Create();
            logicNode.state.CloneFrom(initialState);
            queue.Enqueue(logicNode);

            while (queue.Count > 0)
            {
                LogicNode top = queue.Dequeue();
                processedNodes.Add(top);

                if (goal.Reached(top.state))
                {
                    break;
                }

                //availableActions = availableActions.OrderBy(a => Random.value);
                foreach (IAction a in availableActions)
                {
                    if (top.state.MeetConditions(a.GetRequirements(agent)))
                    {
                        LogicNode next = LogicNode.Create();
                        next.action = a;
                        next.state.CloneFrom(top.state);
                        next.state.ApplyModifications(a.GetEffects(agent));
                        next.previous = top;
                        queue.Enqueue(next);
                    }
                }

                if (queue.Count > 100000)
                {
                    throw new Exception();
                }
            }

            // track back
            List<IAction> actions = new List<IAction>();
            LogicNode last = processedNodes[processedNodes.Count - 1];
            while (last != null && last.action != null)
            {
                actions.Add(last.action);
                last = last.previous;
            }

            actions.Reverse();

            Debug.Log(string.Join("\n", actions.Select(a=>a.GetType().Name)));
            return actions;
        }
    }
}
