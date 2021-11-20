using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.PropLogics
{
    public class PropertyProvider : IPropertyProvider
    {
        public event Action<string, Property, Property> onPropertyChanged;

        private readonly Dictionary<string, Property> dict = new Dictionary<string, Property>();

        public Property Get(string key)
        {
            if (dict.TryGetValue(key, out Property value))
            {
                return value;
            }

            return Property.invalid;
        }

        public IEnumerator<PropertyPair> GetEnumerator()
        {
            return dict.Select(p => new PropertyPair(p.Key, p.Value)).GetEnumerator();
        }

        public bool HasKey(string key)
        {
            return dict.ContainsKey(key);
        }

        public bool RemoveKey(string key)
        {
            return dict.Remove(key);
        }

        public void Reset()
        {
            dict.Clear();
        }

        public void Set(string key, Property value)
        {
            dict[key] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PropertyProvider pp))
            {
                return false;
            }

            if (pp.dict.Count != dict.Count)
            {
                return false;
            }

            foreach (var pair in dict)
            {
                if (!pp.dict.TryGetValue(pair.Key, out Property v))
                {
                    return false;
                }

                if (v != pair.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return dict.GetHashCode();
        }
    }
}
