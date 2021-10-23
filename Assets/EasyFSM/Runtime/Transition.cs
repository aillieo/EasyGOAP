using AillieoUtils.PropLogics;

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
                if (!c.Evaluate(stateMachine.properties))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
