using AillieoUtils.PropLogics;

namespace AillieoUtils.EasyGOAP
{
    public class Goal
    {
        private readonly Condition condition;

        public Goal(Condition condition)
        {
            this.condition = condition;
        }

        public Goal(string key, ConditionMode op, Property value)
            : this(new Condition(key, op, value))
        {
        }

        public bool Reached(WorldState state)
        {
            return condition.Evaluate(state);
        }

        public override bool Equals(object obj)
        {
            if (obj is Goal other)
            {
                return this.condition.Equals(other.condition);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return condition.GetHashCode();
        }
    }
}
