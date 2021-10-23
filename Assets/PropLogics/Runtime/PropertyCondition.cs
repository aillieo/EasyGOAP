using System;

namespace AillieoUtils.PropLogics
{
    public struct PropertyCondition
    {
        public ConditionMode op;
        public Property referenceValue;

        public bool EvaluateWith(Property toTest)
        {
            if (toTest.type != referenceValue.type)
            {
                return false;
            }

            switch (referenceValue.type)
            {
            case Property.ValueType.Int:
                return EvaluateAsInt(ref toTest.value.intValue, ref op, ref referenceValue.value.intValue);
            case Property.ValueType.Float:
                return EvaluateAsFloat(ref toTest.value.floatValue, ref op, ref referenceValue.value.floatValue);
            case Property.ValueType.Bool:
                return EvaluateAsBool(ref toTest.value.boolValue, ref op, ref referenceValue.value.boolValue);
            }

            throw new InvalidOperationException();
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool EvaluateAsInt(ref int toTest, ref ConditionMode op, ref int reference)
        {
            switch (op)
            {
            case ConditionMode.Equal:
                return toTest == reference;
            case ConditionMode.Greater:
                return toTest > reference;
            case ConditionMode.Less:
                return toTest < reference;
            case ConditionMode.NotEqual:
                return toTest != reference;
            case ConditionMode.GreaterEqual:
                return toTest >= reference;
            case ConditionMode.LessEqual:
                return toTest <= reference;
            }

            throw new Exception();
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool EvaluateAsFloat(ref float toTest, ref ConditionMode op, ref float reference)
        {
            switch (op)
            {
            case ConditionMode.Equal:
                return toTest == reference;
            case ConditionMode.Greater:
                return toTest > reference;
            case ConditionMode.Less:
                return toTest < reference;
            case ConditionMode.NotEqual:
                return toTest != reference;
            case ConditionMode.GreaterEqual:
                return toTest >= reference;
            case ConditionMode.LessEqual:
                return toTest <= reference;
            }

            throw new Exception();
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool EvaluateAsBool(ref bool toTest, ref ConditionMode op, ref bool reference)
        {
            switch (op)
            {
            case ConditionMode.Equal:
                return toTest == reference;
            case ConditionMode.NotEqual:
                return toTest != reference;
            }

            throw new Exception();
        }
    }
}
