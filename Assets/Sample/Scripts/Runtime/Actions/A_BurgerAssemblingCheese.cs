using System.Collections.Generic;
using AillieoUtils.GOAP;
using AillieoUtils.PropLogics;

namespace Sample
{
    public class A_BurgerAssemblingCheese : DefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Effect[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(ItemKeyUtils.GetKey(ItemTypes.Bun, ItemStatus.Default), ConditionMode.GreaterEqual, (Property)1),
                new Condition(ItemKeyUtils.GetKey(ItemTypes.Beef, ItemStatus.Cooked), ConditionMode.GreaterEqual, (Property)1),
                new Condition(ItemKeyUtils.GetKey(ItemTypes.Cheese, ItemStatus.Default), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Effect[]
            {
                new Effect(ItemKeyUtils.GetKey(ItemTypes.Bun, ItemStatus.Default), ModifyMode.Substract, (Property)1),
                new Effect(ItemKeyUtils.GetKey(ItemTypes.Beef, ItemStatus.Cooked), ModifyMode.Substract, (Property)1),
                new Effect(ItemKeyUtils.GetKey(ItemTypes.Cheese, ItemStatus.Default), ModifyMode.Substract, (Property)1),
                new Effect(ItemKeyUtils.GetKey(ItemTypes.Burger, ItemStatus.Default), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }
    }
}
