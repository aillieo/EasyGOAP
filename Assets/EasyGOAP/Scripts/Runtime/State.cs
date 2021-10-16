using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.PropLogics;

namespace AillieoUtils.EasyGOAP
{
    public class State
    {
        public readonly IPropertyProvider properties = new PropertyProvider();

        public void CloneFrom(State source)
        {
            properties.Reset();
            MergeFrom(source);
        }

        public void MergeFrom(State source)
        {
            foreach (var pair in source.properties)
            {
                properties.Set(pair.key, pair.value);
            }
        }

        public bool MeetConditions(IEnumerable<Condition> conditions)
        {
            return conditions.All(c => c.Evaluate(properties));
        }

        public void ApplyModifications(IEnumerable<Effect> effects)
        {
            foreach (var e in effects)
            {
                e.ApplyModifications(properties);
            }
        }

        public void Update(string key, Property stateValue)
        {
            properties.Set(key, stateValue);
        }

        public void Update(IEnumerable<PropertyPair> states)
        {
            foreach (var s in states)
            {
                properties.Set(s.key, s.value);
            }
        }

        public override string ToString()
        {
            return string.Join("\n", properties.Select(p => ToString()));
        }
    }
}
