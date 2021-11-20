using System;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public class PlannerAStar : IPlanner
    {
        public interface IHeuristicFuncProvider
        {
            float Heuristic(WorldState state, Goal goal);
        }

        private readonly IHeuristicFuncProvider heuristicFuncProvider;

        public PlannerAStar(IHeuristicFuncProvider heuristicFuncProvider)
        {
            this.heuristicFuncProvider = heuristicFuncProvider;
        }

        public IEnumerable<IAction> FindPath(Agent agent, WorldState initialState, Goal goal, IEnumerable<IAction> availableActions)
        {
            return AStar(agent, initialState, goal, availableActions);
        }

        private IEnumerable<IAction> AStar(Agent agent, WorldState initialState, Goal goal, IEnumerable<IAction> availableActions)
        {
            SimplePriorityQueue<LogicNode> openList = new SimplePriorityQueue<LogicNode>();
            LogicNode start = LogicNode.Create();
            start.state.CloneFrom(initialState);
            start.g = 0;
            start.h = heuristicFuncProvider.Heuristic(start.state, goal);
            openList.Enqueue(start);

            while (openList.Count > 0)
            {
                if (goal.Reached(openList.Peek().state))
                {
                    break;
                }

                LogicNode top = openList.Dequeue();

                foreach (IAction a in availableActions)
                {
                    if (top.state.MeetConditions(a.GetRequirements(agent)))
                    {
                        LogicNode next = LogicNode.Create();
                        next.action = a;
                        next.state.CloneFrom(top.state);
                        next.state.ApplyModifications(a.GetEffects(agent));
                        if (openList.Contains(next))
                        {
                            // todo 可能会更新得到更低的 g
                            continue;
                        }
                        next.previous = top;
                        next.g = top.g + a.GetCost(agent);
                        next.h = heuristicFuncProvider.Heuristic(next.state, goal);
                        openList.Enqueue(next);
                    }
                }

                if (openList.Count > 100000)
                {
                    throw new Exception();
                }
            }

            // track back
            List<IAction> actions = new List<IAction>();
            LogicNode last = openList.Dequeue();
            while (last != null && last.action != null)
            {
                actions.Add(last.action);
                last = last.previous;
            }

            actions.Reverse();

            Debug.Log(string.Join("\n", actions.Select(a => a.GetType().Name)));
            return actions;
        }
    }
}
