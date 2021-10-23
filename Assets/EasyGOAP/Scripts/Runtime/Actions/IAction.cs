using AillieoUtils.PropLogics;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public interface IAction
    {
        WorldState GetAssociatedState();

        IEnumerable<Condition> GetRequirements();

        IEnumerable<Modification> GetEffects();

        float GetCost();

        ActionResult Execute(float deltaTime);

        void OnBeginExecute();

        void OnEndExecute(ActionResult result);
    }
}
