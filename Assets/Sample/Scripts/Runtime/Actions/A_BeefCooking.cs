using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    public class A_BeefCooking : DefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Modification[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Chopped), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Modification[]
            {
                new Modification(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Chopped), ModifyMode.Substract, (Property)1),
                new Modification(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Cooked), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }

        public override void OnBeginExecute(Agent agent)
        {
            base.OnBeginExecute(agent);
            Vector2 targetPosition = GameManager.Instance.GetTablePosition("Cooker");
            agent.GetStateMachine().SetVector2(InternalKeys.targetPosition, targetPosition);
            agent.GetStateMachine().SetFloat(InternalKeys.distanceToTarget, Vector2.Distance(agent.GetPosition(), targetPosition));
        }
    }
}
