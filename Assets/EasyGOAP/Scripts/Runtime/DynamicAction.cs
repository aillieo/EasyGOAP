using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.GOAP
{
    public class DynamicAction : IAction
    {
        private readonly Condition[] requirements;
        private readonly Effect[] effects;
        private readonly float cost;

        public DynamicAction(Condition[] reqs, Effect[] effs, float cst)
        {
            this.requirements = reqs;
            this.effects = effs;
            this.cost = cst;
        }

        public IEnumerable<Condition> GetRequirements()
        {
            return requirements;
        }

        public IEnumerable<Effect> GetEffects()
        {
            return effects;
        }

        public float GetCost()
        {
            return cost;
        }
    }
}
