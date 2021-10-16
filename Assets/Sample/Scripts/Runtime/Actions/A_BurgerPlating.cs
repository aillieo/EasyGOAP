using System.Collections.Generic;
using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class A_BurgerPlating : DefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Effect[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Default), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Effect[]
            {
                new Effect(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Default), ModifyMode.Substract, (Property)1),
                new Effect(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Plated), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }
    }
}
