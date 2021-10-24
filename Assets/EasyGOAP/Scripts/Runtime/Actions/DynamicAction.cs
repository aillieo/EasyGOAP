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

        public IEnumerable<Condition> GetRequirements(Agent agent)
        {
            return requirements;
        }

        public IEnumerable<Modification> GetEffects(Agent agent)
        {
            return effects;
        }

        public float GetCost(Agent agent)
        {
            return cost;
        }

        public ActionResult Execute(Agent agent, float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void OnBeginExecute(Agent agent)
        {
            throw new System.NotImplementedException();
        }

        public void OnEndExecute(Agent agent, ActionResult result)
        {
            throw new System.NotImplementedException();
        }
    }
}
