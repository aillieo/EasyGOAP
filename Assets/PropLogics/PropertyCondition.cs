using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    public struct PropertyCondition
    {
        public ConditionMode op;
        public Property referenceValue;

        public bool EvaluateWith(Property toTest)
        {
            switch (referenceValue.type)
            {
            case Property.ValueType.Int:
                break;
            case Property.ValueType.Float:
                break;
            case Property.ValueType.Bool:
                break;
            }

            return false;
        }
    }
}
