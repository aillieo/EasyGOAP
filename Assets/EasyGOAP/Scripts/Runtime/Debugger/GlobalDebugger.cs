using AillieoUtils.PropLogics;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public static class GlobalDebugger
    {
        internal class StateInfo
        {
            public string name;
            public IPropertyProvider state;
        }

        internal static readonly List<StateInfo> states = new List<StateInfo>();

        public static void RecordState(string key, IPropertyProvider state)
        {
            for (int i = states.Count - 1; i >= 0; --i)
            {
                StateInfo info = states[i];
                if (key == info.name || ReferenceEquals(state, info.state))
                {
                    states.RemoveAt(i);
                }
            }

            StateInfo newInfo = new StateInfo()
            {
                state = state,
                name = key,
            };
            states.Add(newInfo);
        }

        public static void RemoveState(string key)
        {
            for (int i = states.Count - 1; i >= 0; --i)
            {
                StateInfo info = states[i];
                if (key == info.name)
                {
                    states.RemoveAt(i);
                }
            }
        }
    }
}
