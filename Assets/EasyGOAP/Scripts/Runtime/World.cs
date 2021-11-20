using AillieoUtils.PropLogics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.EasyGOAP
{
    public class World
    {
        public World(IPlanner planner)
        {
            this.planner = planner;
        }

        private readonly WorldState worldState = new WorldState();
        private readonly IPlanner planner;

        public Agent CreateAgent()
        {
            return new Agent(this);
        }

        public WorldState GetWorldState()
        {
            return worldState;
        }

        public IPlanner GetPlanner()
        {
            return planner;
        }

        public IEnumerable<IAction> FindPath(Agent agent, Goal goal, IEnumerable<IAction> availableActions)
        {
            return planner.FindPath(agent, worldState, goal, availableActions);
        }
    }
}
