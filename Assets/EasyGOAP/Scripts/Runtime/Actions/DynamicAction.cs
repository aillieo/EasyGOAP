using AillieoUtils.PropLogics;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public class DynamicAction : IAction
    {
        private readonly WorldState state;
        private readonly Condition[] requirements;
        private readonly Modification[] effects;
        private readonly float cost;

        public DynamicAction(WorldState state, Condition[] reqs, Modification[] effs, float cst)
        {
            this.state = state;
            this.requirements = reqs;
            this.effects = effs;
            this.cost = cst;
        }

        public IEnumerable<Condition> GetRequirements()
        {
            return requirements;
        }

        public IEnumerable<Modification> GetEffects()
        {
            return effects;
        }

        public float GetCost()
        {
            return cost;
        }

        public ActionResult Execute(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void OnBeginExecute()
        {
            throw new System.NotImplementedException();
        }

        public void OnEndExecute(ActionResult result)
        {
            throw new System.NotImplementedException();
        }

        public WorldState GetAssociatedState()
        {
            return this.state;
        }
    }
}
