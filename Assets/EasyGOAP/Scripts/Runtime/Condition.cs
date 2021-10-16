using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
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

        public bool Evaluate(IPropertyProvider properties)
        {
            Property prop = properties.Get(key);
            if (!prop.Valid())
            {
                return false;
            }

            return propertyCondition.EvaluateWith(prop);
        }
    }
}
