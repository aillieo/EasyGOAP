using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    public class PropertyProvider : IPropertyProvider
    {
        private readonly Dictionary<string, Property> dict = new Dictionary<string, Property>();

        public Property Get(string key)
        {
            return dict[key];
        }

        public bool HasKey(string key)
        {
            return dict.ContainsKey(key);
        }

        public bool RemoveKey(string key)
        {
            return dict.Remove(key);
        }

        public void Set(string key, Property value)
        {
            dict[key] = value;
        }
    }
}
