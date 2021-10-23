using System.Collections;
using System.Collections.Generic;
using AillieoUtils.PropLogics;
using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = "EasyGOAPSample/StateAsset", fileName = "StateAsset")]
    public class StateAsset : ScriptableObject, IEnumerable<PropertyPair>
    {
        [SerializeField]
        private PropertyPair[] entries;

        public IEnumerator<PropertyPair> GetEnumerator()
        {
            foreach (var pair in entries)
            {
                yield return new PropertyPair(pair.key, pair.value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
