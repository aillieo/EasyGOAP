using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.GOAP
{
    public class Condition
    {
        public readonly string key;
        public readonly ConditionMode op;
        public readonly Property value;

        public Condition(string key, ConditionMode op, Property value)
        {
            this.key = key;
            this.op = op;
            this.value = value;
        }

        public bool Evaluate()
        {
            // todo
            // Property curValue = Get(key);
            Property curValue = default;
            return false;
        }
    }
}
