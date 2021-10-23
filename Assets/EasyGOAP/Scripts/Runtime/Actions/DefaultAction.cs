using AillieoUtils.PropLogics;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public abstract class DefaultAction : IAction
    {
        private Condition[] requirements;
        private Modification[] effects;
        private float cost;
        private bool hasData = false;
        private float timer;

        public IEnumerable<Condition> GetRequirements()
        {
            EnsureData();
            return requirements;
        }

        public IEnumerable<Modification> GetEffects()
        {
            EnsureData();
            return effects;
        }

        public float GetCost()
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

            GetData(out requirements, out effects, out cost);
            hasData = true;
        }

        public virtual ActionResult Execute(float deltaTime)
        {
            EnsureData();

            if (!GetAssociatedState().MeetConditions(GetRequirements()))
            {
                return ActionResult.Failed;
            }

            timer += deltaTime * 10;

            if (timer >= cost)
            {
                return ActionResult.Success;
            }
            else
            {
                return ActionResult.Unfinished;
            }
        }

        public virtual void OnBeginExecute()
        {
            UnityEngine.Debug.LogError($"Begin {GetType()}");
            EnsureData();
            timer = 0;
        }

        public virtual void OnEndExecute(ActionResult result)
        {
            EnsureData();
            timer = 0;

            UnityEngine.Debug.LogError($"End {GetType()}");
        }

        public abstract WorldState GetAssociatedState();
    }
}
