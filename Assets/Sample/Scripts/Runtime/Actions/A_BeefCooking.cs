using System.Collections.Generic;
using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class A_BeefCooking : DefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Effect[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Chopped), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Effect[]
            {
                new Effect(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Chopped), ModifyMode.Substract, (Property)1),
                new Effect(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Cooked), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }
    }
}
