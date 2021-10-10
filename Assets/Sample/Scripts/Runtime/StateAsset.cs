using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = "EasyGOAPSample/StateAsset", fileName = "StateAsset")]
    public class StateAsset : ScriptableObject, IEnumerable<KeyValuePair<string, Property>>
    {
        [Serializable]
        public class Entry
        {
            public string key;
            public Property value;
        }

        [SerializeField]
        private Entry[] entries;

        public IEnumerator<KeyValuePair<string, Property>> GetEnumerator()
        {
            foreach (var pair in entries)
            {
                yield return new KeyValuePair<string, Property>(pair.key, pair.value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
