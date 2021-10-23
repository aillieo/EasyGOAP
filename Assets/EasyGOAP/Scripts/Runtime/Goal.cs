using AillieoUtils.PropLogics;

namespace AillieoUtils.EasyGOAP
{
    public class Goal
    {
        public readonly Condition condition;
        public float weight = 1f;

        public Goal(Condition condition)
        {
            this.condition = condition;
        }

        public bool Reached()
        {
            return condition.Evaluate(null);
        }
    }
}
