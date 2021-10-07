using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.GOAP
{
    public abstract class DefaultAction : IAction
    {
        private Condition[] requirements;
        private Effect[] effects;
        private float cost;
        private bool hasData = false;

        public IEnumerable<Condition> GetRequirements()
        {
            EnsureData();
            return requirements;
        }

        public IEnumerable<Effect> GetEffects()
        {
            EnsureData();
            return effects;
        }

        public float GetCost()
        {
            EnsureData();
            return cost;
        }

        protected abstract void GetData(out Condition[] reqs, out Effect[] effs, out float cst);

        private void EnsureData()
        {
            if (hasData)
            {
                return;
            }

            GetData(out requirements, out effects, out cost);
            hasData = true;
        }
    }
}
