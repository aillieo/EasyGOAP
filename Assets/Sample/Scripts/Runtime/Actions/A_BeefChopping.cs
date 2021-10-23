using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class A_BeefChopping : SampleDefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Modification[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Raw), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Modification[]
            {
                new Modification(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Raw), ModifyMode.Substract, (Property)1),
                new Modification(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Chopped), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }
    }
}
