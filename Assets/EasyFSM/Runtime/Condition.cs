using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.FSM
{
    public class Condition
    {
        public readonly string key;
        public readonly PropertyCondition propertyCondition;

        public Condition(string key, ConditionMode op, Property value)
        {
            this.key = key;
            this.propertyCondition = new PropertyCondition()
            {
                op = op,
                referenceValue = value,
            };
        }

        public bool Evaluate()
        {
            // todo
            // Property curValue = Get(key);
            Property curValue = default;
            return propertyCondition.EvaluateWith(curValue);
        }
    }
}
