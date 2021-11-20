using System;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public interface IPlanner
    {
        IEnumerable<IAction> FindPath(Agent agent, WorldState initialState, Goal goal, IEnumerable<IAction> availableActions);
    }
}
