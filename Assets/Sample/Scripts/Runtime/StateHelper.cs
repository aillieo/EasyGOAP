using System.Collections;
using System.Collections.Generic;
using AillieoUtils.EasyGOAP;
using UnityEngine;

namespace Sample
{
    public static class StateHelper
    {
        public static string HashItemKey(string itemType, string itemStatus)
        {
            if (itemStatus == ItemStatus.Default)
            {
                return itemType;
            }

            return $"{itemType}_{itemStatus}";
        }

        public static int GetItemCount(State state, string itemType, string itemStatus)
        {
            return state.properties.Get(HashItemKey(itemType, itemStatus));
        }

        public static void SetItemCount(State state, string itemType, string itemStatus, int count)
        {
            state.properties.Set(HashItemKey(itemType, itemStatus), count);
        }

        public static void ChangeItemCount(State state, string itemType, string itemStatus, int change)
        {
            string key = HashItemKey(itemType, itemStatus);
            int count = state.properties.Get(key);
            state.properties.Set(key, count + change);
        }

        public static void HashPosKey(string rawKey, out string xKey, out string yKey)
        {
            xKey = $"{rawKey}__pos_x_";
            yKey = $"{rawKey}__pos_y_";
        }

        public static Vector2 GetPosition(State state, string key)
        {
            HashPosKey(key, out string xKey, out string yKey);
            float x = state.properties.Get(xKey);
            float y = state.properties.Get(yKey);
            return new Vector2(x, y);
        }

        public static void SetPosition(State state, string key, Vector2 position)
        {
            HashPosKey(key, out string xKey, out string yKey);
            state.properties.Set(xKey, position.x);
            state.properties.Set(yKey, position.y);
        }

        public static string GetObjNameKey<T>(string name)
        {
            return $"{typeof(T).Name}_{name}__";
        }

        public static string GetObjNameKey<T>(T obj) where T : MonoBehaviour
        {
            return GetObjNameKey<T>(obj.name);
        }

        public static void SaveObjPosition<T>(State state, T obj) where T : MonoBehaviour
        {
            Vector2 pos = obj.transform.position.ToVector2();
            SetPosition(state, GetObjNameKey(obj), pos);
        }

        public static void RetrieveObjPosition<T>(State state, T obj) where T : MonoBehaviour
        {
            Vector2 pos = GetPosition(state, GetObjNameKey(obj));
            obj.transform.position = pos.ToVector3();
        }
    }
}
