using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    public static class IPropertyProviderExt
    {
        public static Property GetOrDefault(this IPropertyProvider propertyProvider, string key, Property defaultValue)
        {
            Property prop = propertyProvider.Get(key);
            if (prop.Valid())
            {
                return prop;
            }

            return defaultValue;
        }
    }
}
