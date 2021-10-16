using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.FSM
{
    internal class Transition
    {
        internal readonly IState toState;
        private Condition[] conditions;

        internal Transition(IState toState, Condition[] conditions)
        {
            this.toState = toState;
            this.conditions = conditions;
        }

        internal bool CheckCondition(StateMachine stateMachine)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return false;
            }

            foreach (var c in conditions)
            {
                if (!c.Evaluate())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
