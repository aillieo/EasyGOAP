using AillieoUtils.PropLogics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.EasyGOAP
{
    public class World
    {
        private readonly WorldState worldState = new WorldState();
        private readonly Planner planner = new Planner();

        public Agent CreateAgent()
        {
            return new Agent(this);
        }

        public WorldState GetWorldState()
        {
            return worldState;
        }

        public IEnumerable<IAction> FindPath(Goal goal, IEnumerable<IAction> availableActions)
        {
            return planner.FindPath(worldState, goal, availableActions);
        }
    }
}
