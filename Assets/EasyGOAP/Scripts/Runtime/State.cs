using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public class State
    {

        private static readonly Stack<State> pool = new Stack<State>();

        public static State Create()
        {
            if (pool.Count > 0)
            {
                return pool.Pop();
            }

            return new State();
        }

        public static void Recycle(State state)
        {
            state.properties.Reset();
            if (pool.Count < 128)
            {
                pool.Push(state);
            }
        }

        private State()
        {
        }

        public readonly IPropertyProvider properties = new PropertyProvider();

        public State Clone()
        {
            State newState = Create();
            foreach (var pair in this.properties)
            {
                newState.properties.Set(pair.key, pair.value);
            }

            return newState;
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
