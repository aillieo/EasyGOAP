using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AillieoUtils.PropLogics
{
    [Serializable]
    public struct Property
    {
        public Value value;
        public ValueType type;
        internal static readonly Property invalid = new Property() { type = ValueType.Invalid };

        public bool Valid()
        {
            return type != ValueType.Invalid;
        }

        public override string ToString()
        {
            switch (type)
            {
            case ValueType.Invalid:
                return $"({nameof(ValueType.Invalid)})";
            case ValueType.Int:
                return $"{value.intValue}({nameof(ValueType.Int)})";
            case ValueType.Float:
                return $"{value.floatValue}({nameof(ValueType.Float)})";
            case ValueType.Bool:
                return $"{value.boolValue}({nameof(ValueType.Bool)})";
            }

            throw new NotImplementedException();
        }

        public enum ValueType : byte
        {
            Invalid = 0,
            Int = 1,
            Float = 2,
            Bool = 3,
        }

        [Serializable]
        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public struct Value
        {
            [FieldOffset(0)]
            [NonSerialized]
            public float floatValue;

            [FieldOffset(0)]
            public int intValue;

            [FieldOffset(0)]
            [NonSerialized]
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
                value = new Value()
                {
                    floatValue = value,
                },
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
                value = new Value()
                {
                    intValue = value,
                },
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
                value = new Value()
                {
                    boolValue = value,
                },
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Property prop)
            {
                if (this.type != prop.type)
                {
                    return false;
                }

                switch (this.type)
                {
                case ValueType.Invalid:
                    return true;
                case ValueType.Int:
                    return this.value.intValue == prop.value.intValue;
                case ValueType.Float:
                    return this.value.floatValue == prop.value.floatValue;
                case ValueType.Bool:
                    return this.value.boolValue == prop.value.boolValue;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (type == ValueType.Invalid)
            {
                return 0;
            }

            return this.type.GetHashCode() ^ this.value.intValue.GetHashCode() << 2;
        }
    }
}
