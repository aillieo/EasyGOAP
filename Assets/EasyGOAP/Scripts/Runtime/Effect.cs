using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.GOAP
{
    public class Effect
    {
        public readonly string key;
        public readonly ModifyMode op;
        public readonly Property value;

        public Effect(string key, ModifyMode op, Property value)
        {
            this.key = key;
            this.op = op;
            this.value = value;
        }

        public void ApplyModifications()
        {

        }
    }
}
