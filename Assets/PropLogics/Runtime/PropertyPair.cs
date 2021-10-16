using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    [Serializable]
    public struct PropertyPair
    {
        public string key;
        public Property value;

        public PropertyPair(string key, Property value)
        {
            this.key = key;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{key} = {value}";
        }
    }
}
