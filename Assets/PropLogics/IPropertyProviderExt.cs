using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    public static class IPropertyProviderExt
    {
        public static Property GetOrDefault(this IPropertyProvider propertyProvider, string key, Property defaultValue)
        {
            if (propertyProvider.HasKey(key))
            {
                return propertyProvider.Get(key);
            }

            return defaultValue;
        }
    }
}
