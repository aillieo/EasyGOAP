using AillieoUtils.PropLogics;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public class Goal
    {
        private readonly Condition[] conditions;

        public Goal(Condition[] conditions)
        {
            this.conditions = conditions;
        }

        public Goal(Condition condition)
            : this(new Condition[] { condition })
        {
        }

        public Goal(string key, ConditionMode op, Property value)
            : this(new Condition[] { new Condition(key, op, value) })
        {
        }

        public bool Reached(WorldState state)
        {
            foreach (var condition in conditions)
            {
                if (!condition.Evaluate(state))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Reached(WorldState state, List<Condition> failedToFill)
        {
            bool reached = true;
            foreach (var condition in conditions)
            {
                if (!condition.Evaluate(state))
                {
                    reached = false;
                    failedToFill.Add(condition);
                }
            }
            return reached;
        }

        // todo 逐个 condition 对比
        //public override bool Equals(object obj)
        //{
        //    if (obj is Goal other)
        //    {
        //        return this.conditions.Equals(other.conditions);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public override int GetHashCode()
        //{
        //    return conditions.GetHashCode();
        //}
    }
}
