using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.FSM
{
    public interface ICondition
    {
        bool Evaluate();
    }
}
