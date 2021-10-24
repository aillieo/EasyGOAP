using AillieoUtils.EasyGOAP;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    public class A_BurgerPlating : DefaultAction
    {
        protected override void GetData(out Condition[] reqs, out Modification[] effs, out float cst)
        {
            reqs = new Condition[]
            {
                new Condition(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Default), ConditionMode.GreaterEqual, (Property)1),
            };

            effs = new Modification[]
            {
                new Modification(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Default), ModifyMode.Substract, (Property)1),
                new Modification(StateHelper.HashItemKey(ItemTypes.Burger, ItemStatus.Plated), ModifyMode.Add, (Property)1),
            };

            cst = 1;
        }

        public override void OnBeginExecute(Agent agent)
        {
            base.OnBeginExecute(agent);
            Vector2 targetPosition = GameManager.Instance.GetTablePosition("Plating");
            agent.GetStateMachine().SetVector2(InternalKeys.targetPosition, targetPosition);
            agent.GetStateMachine().SetFloat(InternalKeys.distanceToTarget, Vector2.Distance(agent.GetPosition(), targetPosition));
        }
    }
}
