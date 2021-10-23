using System;

namespace AillieoUtils.PropLogics
{
    [Flags]
    public enum ConditionMode : byte
    {
        Equal = 0b0001,
        Greater = 0b0010,
        Less = 0b0100,
        NotEqual = 0b0110,
        GreaterEqual = 0b0011,
        LessEqual = 0b0101,
    }
}
