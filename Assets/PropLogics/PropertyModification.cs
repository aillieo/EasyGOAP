using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    public struct PropertyModification
    {
        public ModifyMode op;
        public Property operand;

        public Property ApplyModification(Property inputValue)
        {
            if (op == ModifyMode.Replace)
            {
                return operand;
            }

            if (!inputValue.Valid())
            {
                inputValue = new Property()
                {
                    type = operand.type,
                    value = default,
                };
            }

            if (inputValue.type != operand.type)
            {
                throw new InvalidOperationException();
            }

            switch (operand.type)
            {
            case Property.ValueType.Int:
                return ModifyInt(ref inputValue.value.intValue, ref op, ref operand.value.intValue);
            case Property.ValueType.Float:
                return ModifyFloat(ref inputValue.value.floatValue, ref op, ref operand.value.floatValue);
            case Property.ValueType.Bool:
                return ModifyBool(ref inputValue.value.boolValue, ref op, ref operand.value.boolValue);
            }

            throw new InvalidOperationException();
        }

        private int ModifyInt(ref int lhs, ref ModifyMode op, ref int rhs)
        {
            switch (op)
            {
            case ModifyMode.Add:
                return lhs + rhs;
            case ModifyMode.Substract:
                return lhs - rhs;
            case ModifyMode.Multiply:
                return lhs * rhs;
            case ModifyMode.Divide:
                return lhs / rhs;
            case ModifyMode.Replace:
                return rhs;
            }

            throw new InvalidOperationException();
        }

        private float ModifyFloat(ref float lhs, ref ModifyMode op, ref float rhs)
        {
            switch (op)
            {
            case ModifyMode.Add:
                return lhs + rhs;
            case ModifyMode.Substract:
                return lhs - rhs;
            case ModifyMode.Multiply:
                return lhs * rhs;
            case ModifyMode.Divide:
                return lhs / rhs;
            case ModifyMode.Replace:
                return rhs;
            }

            throw new InvalidOperationException();
        }

        private bool ModifyBool(ref bool lhs, ref ModifyMode op, ref bool rhs)
        {
            switch (op)
            {
            case ModifyMode.Or:
                return lhs || rhs;
            case ModifyMode.And:
                return lhs && rhs;
            case ModifyMode.Not:
                return !lhs;
            case ModifyMode.Replace:
                return rhs;
            }

            throw new InvalidOperationException();
        }
    }
}
