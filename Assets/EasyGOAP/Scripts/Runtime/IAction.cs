using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public interface IAction
    {
        IEnumerable<Condition> GetRequirements();

        IEnumerable<Effect> GetEffects();

        float GetCost();
    }
}
