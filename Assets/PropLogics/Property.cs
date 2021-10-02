using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AillieoUtils.PropLogics
{
    public struct Property
    {
        public Value value;
        public ValueType type;

        public enum ValueType : byte
        {
            Int = 0,
            Float = 1,
            Bool = 2,
        }

        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public struct Value
        {
            [FieldOffset(0)]
            public float floatValue;

            public static implicit operator float(Value value)
            {
                return value.floatValue;
            }

            public static implicit operator Value(float value)
            {
                return new Value()
                {
                    floatValue = value,
                };
            }

            [FieldOffset(0)]
            public int intValue;

            public static implicit operator int(Value value)
            {
                return value.intValue;
            }

            public static implicit operator Value(int value)
            {
                return new Value()
                {
                    intValue = value,
                };
            }

            [FieldOffset(0)]
            public bool boolValue;

            public static implicit operator bool(Value value)
            {
                return value.boolValue;
            }

            public static implicit operator Value(bool value)
            {
                return new Value()
                {
                    boolValue = value,
                };
            }
        }
    }
}
