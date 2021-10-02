using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.GOAP
{
    public interface IAction
    {
        IEnumerable<Condition> requirement { get; }

        IEffect effects { get; }
    }
}
