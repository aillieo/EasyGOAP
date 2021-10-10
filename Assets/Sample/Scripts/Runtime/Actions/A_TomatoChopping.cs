using System.Collections.Generic;
using AillieoUtils.GOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class A_TomatoChopping : DefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Effect[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(ItemKeyUtils.GetKey(ItemTypes.Tomato, ItemStatus.Raw), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Effect[]
            {
                new Effect(ItemKeyUtils.GetKey(ItemTypes.Tomato, ItemStatus.Raw), ModifyMode.Substract, (Property)1),
                new Effect(ItemKeyUtils.GetKey(ItemTypes.Tomato, ItemStatus.Chopped), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }
    }
}
