using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.FSM
{
    public class Condition : ICondition
    {
        public enum Operator
        {
            Equal = 0,
            NotEqual = 1,
            Greater = 2,
            GreaterEqual = 3,
            Less = 4,
            LessEqual = 5,
        }

        public readonly string key;
        public readonly Operator op;
        public readonly float criteria;

        public Condition(string key, Operator op, float criteria)
        {
            this.key = key;
            this.op = op;
            this.criteria = criteria;
        }

        public bool Evaluate()
        {
            return false;
        }
    }
}
