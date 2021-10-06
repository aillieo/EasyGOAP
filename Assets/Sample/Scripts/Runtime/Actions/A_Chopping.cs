using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.GOAP;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    public class A_Chopping : IAction
    {
        public IEnumerable<Condition> requirement => cons;
        public IEnumerable<Effect> effects => effs;

        private List<Condition> cons = new List<Condition>()
        {
            new Condition(ItemTypes.Beef, ConditionMode.GreaterEqual, (Property)1),
        };

        private List<Effect> effs = new List<Effect>()
        {
            new Effect(ItemTypes.Beef, ModifyMode.Substract, (Property)1),
        };
    }
}
