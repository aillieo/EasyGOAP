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

            [FieldOffset(0)]
            public int intValue;

            [FieldOffset(0)]
            public bool boolValue;
        }

        public static implicit operator float(Property prop)
        {
            return prop.value.floatValue;
        }

        public static implicit operator Property(float value)
        {
            return new Property()
            {
                type = ValueType.Float,
                value = new Value(){floatValue = value},
            };
        }

        public static implicit operator int(Property prop)
        {
            return prop.value.intValue;
        }

        public static implicit operator Property(int value)
        {
            return new Property()
            {
                type = ValueType.Int,
                value = new Value(){intValue = value},
            };
        }

        public static implicit operator bool(Property prop)
        {
            return prop.value.boolValue;
        }

        public static implicit operator Property(bool value)
        {
            return new Property()
            {
                type = ValueType.Bool,
                value = new Value(){boolValue = value},
            };
        }

    }
}
