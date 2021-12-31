using AillieoUtils.PropLogics;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

        public static void CloneFrom(this IPropertyProvider propertyProvider, IPropertyProvider source)
        {
            propertyProvider.Reset();
            propertyProvider.MergeFrom(source);
        }

        public static void MergeFrom(this IPropertyProvider propertyProvider, IPropertyProvider source)
        {
            foreach (var pair in source)
            {
                propertyProvider.Set(pair.key, pair.value);
            }
        }

        public static bool MeetConditions(this IPropertyProvider propertyProvider, IEnumerable<Condition> conditions)
        {
            return conditions.All(c => c.Evaluate(propertyProvider));
        }

        public static bool MeetConditions(this IPropertyProvider propertyProvider, IEnumerable<Condition> conditions, List<Condition> failedToFill)
        {
            bool meet = true;
            foreach (var condition in conditions)
            {
                if (!condition.Evaluate(propertyProvider))
                {
                    meet = false;
                    failedToFill.Add(condition);
                }
            }
            return meet;
        }

        public static void ApplyModifications(this IPropertyProvider propertyProvider, IEnumerable<Modification> modifications)
        {
            foreach (var m in modifications)
            {
                m.ApplyModifications(propertyProvider);
            }
        }

        public static void Update(this IPropertyProvider propertyProvider, IEnumerable<PropertyPair> states)
        {
            foreach (var s in states)
            {
                propertyProvider.Set(s.key, s.value);
            }
        }

        public static string PrintProperties(this IPropertyProvider propertyProvider)
        {
            return string.Join("\n", propertyProvider.Select(p => p.ToString()));
        }
    }
}
