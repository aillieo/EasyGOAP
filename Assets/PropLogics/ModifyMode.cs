using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    [Flags]
    public enum ModifyMode : byte
    {
        Add = 0b0100,
        Substract = 0b0101,
        Multiply = 0b0110,
        Divide = 0b0111,

        Or = 0b1000,
        And = 0b1001,
        Not = 0b1010,

        Replace = 0b1100,
    }
}
