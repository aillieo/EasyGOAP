using AillieoUtils.PropLogics;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public interface IAction
    {
        IEnumerable<Condition> GetRequirements(Agent agent);

        IEnumerable<Modification> GetEffects(Agent agent);

        float GetCost(Agent agent);

        ActionResult Execute(Agent agent, float deltaTime);

        void OnBeginExecute(Agent agent);

        void OnEndExecute(Agent agent, ActionResult result);
    }
}
