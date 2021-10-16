using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AillieoUtils.FSM
{
    public class TransitionBuilder
    {
        internal readonly IState fromState;
        internal readonly IState toState;

        internal int priority = 0;
        private HashSet<Condition> conditions;

        internal TransitionBuilder(IState fromState, IState toState)
        {
            this.fromState = fromState;
            this.toState = toState;
        }

        public TransitionBuilder SetPriority(int priority)
        {
            this.priority = priority;
            return this;
        }

        public TransitionBuilder AddCondition(Condition condition)
        {
            if (conditions == null)
            {
                conditions = new HashSet<Condition>();
            }

            conditions.Add(condition);

            return this;
        }

        internal Transition ToTransition()
        {
            return new Transition(this.toState, this.conditions.ToArray());
        }
    }
}
