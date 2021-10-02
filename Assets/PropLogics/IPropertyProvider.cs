using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.PropLogics
{
    public interface IPropertyProvider
    {
        bool HasKey(string key);

        bool RemoveKey(string key);

        void Set(string key, Property value);

        Property Get(string key);
    }
}