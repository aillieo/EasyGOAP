using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.GOAP
{
    public class Effect
    {
        public readonly string key;
        public readonly PropertyModification propertyModification;

        public Effect(string key, ModifyMode op, Property value)
        {
            this.key = key;
            this.propertyModification = new PropertyModification()
            {
                op = op,
                operand = value,
            };
        }

        public void ApplyModifications(IPropertyProvider properties)
        {
            Property prop = properties.Get(key);
            properties.Set(key, propertyModification.ApplyModification(prop));
        }
    }
}
