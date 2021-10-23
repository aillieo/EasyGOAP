using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class A_BurgerAssemblingCheese : SampleDefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Modification[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(StateHelper.HashItemKey(ItemTypes.Bun, ItemStatus.Default), ConditionMode.GreaterEqual, (Property)1),
                new Condition(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Cooked), ConditionMode.GreaterEqual, (Property)1),
                new Condition(StateHelper.HashItemKey(ItemTypes.Cheese, ItemStatus.Default), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Modification[]
            {
                new Modification(StateHelper.HashItemKey(ItemTypes.Bun, ItemStatus.Default), ModifyMode.Substract, (Property)1),
                new Modification(StateHelper.HashItemKey(ItemTypes.Beef, ItemStatus.Cooked), ModifyMode.Substract, (Property)1),
                new Modification(StateHelper.HashItemKey(ItemTypes.Cheese, ItemStatus.Default), ModifyMode.Substract, (Property)1),
                new Modification(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Default), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }
    }
}
