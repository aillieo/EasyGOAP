using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

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

        public IEnumerator<KeyValuePair<string, Property>> GetEnumerator()
        {
            return dict.GetEnumerator();
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
            UnityEngine.Debug.LogError($"属性变化 {key} {Get(key)} -> {value}");
            dict[key] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
