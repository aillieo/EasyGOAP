using System;
using System.Collections.Generic;
using AillieoUtils.EasyGOAP;

namespace Sample
{
    public class HeuristicSample : PlannerAStar.IHeuristicFuncProvider
    {
        public float Heuristic(WorldState state, Goal goal)
        {
            throw new NotImplementedException();
        }
    }
}
