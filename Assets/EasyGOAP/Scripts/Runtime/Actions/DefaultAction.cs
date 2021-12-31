using AillieoUtils.PropLogics;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public abstract class DefaultAction : IAction
    {
        private Condition[] preconditions;
        private Modification[] effects;
        private float cost;
        private bool hasData = false;
        private float timer;

        public IEnumerable<Condition> GetPreconditions(Agent agent)
        {
            EnsureData();
            return preconditions;
        }

        public IEnumerable<Modification> GetEffects(Agent agent)
        {
            EnsureData();
            return effects;
        }

        public float GetCost(Agent agent)
        {
            EnsureData();
            return cost;
        }

        protected abstract void GetData(out Condition[] reqs, out Modification[] effs, out float cst);

        private void EnsureData()
        {
            if (hasData)
            {
                return;
            }

            GetData(out preconditions, out effects, out cost);
            hasData = true;
        }

        public virtual ActionResult Execute(Agent agent, float deltaTime)
        {
            EnsureData();

            if (!agent.GetWorld().GetWorldState().MeetConditions(GetPreconditions(agent)))
            {
                return ActionResult.Failed;
            }

            timer += deltaTime;

            if (timer >= cost)
            {
                return ActionResult.Success;
            }
            else
            {
                return ActionResult.Unfinished;
            }
        }

        public virtual void OnBeginExecute(Agent agent)
        {
            EnsureData();
            timer = 0;
        }

        public virtual void OnEndExecute(Agent agent, ActionResult result)
        {
            EnsureData();

            if (result == ActionResult.Success)
            {
                agent.GetWorld().GetWorldState().ApplyModifications(GetEffects(agent));
            }

            timer = 0;
        }
    }
}
