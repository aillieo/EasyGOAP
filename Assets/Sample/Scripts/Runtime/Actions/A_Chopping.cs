using System.Collections.Generic;
using AillieoUtils.GOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class A_Chopping : DefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Effect[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(ItemTypes.Beef, ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Effect[]
            {
                new Effect(ItemTypes.Beef, ModifyMode.Substract, (Property)1),
            };

            cst = 1;
        }
    }
}
