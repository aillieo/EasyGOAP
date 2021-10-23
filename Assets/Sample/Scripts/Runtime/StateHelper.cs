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

        public static int GetItemCount(WorldState state, string itemType, string itemStatus)
        {
            return state.Get(HashItemKey(itemType, itemStatus));
        }

        public static void SetItemCount(WorldState state, string itemType, string itemStatus, int count)
        {
            state.Set(HashItemKey(itemType, itemStatus), count);
        }

        public static void ChangeItemCount(WorldState state, string itemType, string itemStatus, int change)
        {
            string key = HashItemKey(itemType, itemStatus);
            int count = state.Get(key);
            state.Set(key, count + change);
        }

        public static void HashPosKey(string rawKey, out string xKey, out string yKey)
        {
            xKey = $"{rawKey}_pos_x__";
            yKey = $"{rawKey}_pos_y__";
        }

        public static Vector2 GetPosition(WorldState state, string key)
        {
            HashPosKey(key, out string xKey, out string yKey);
            float x = state.Get(xKey);
            float y = state.Get(yKey);
            return new Vector2(x, y);
        }

        public static void SetPosition(WorldState state, string key, Vector2 position)
        {
            HashPosKey(key, out string xKey, out string yKey);
            state.Set(xKey, position.x);
            state.Set(yKey, position.y);
        }

        public static string GetObjNameKey<T>(T obj) where T : MonoBehaviour
        {
            return $"{typeof(T).Name}_{obj.name}({obj.GetInstanceID()})__";
        }

        public static Vector2 SaveObjPosition<T>(WorldState state, T obj) where T : SceneObj
        {
            Vector2 pos = obj.transform.position.ToVector2();
            SetPosition(state, GetObjNameKey(obj), pos);
            return pos;
        }

        public static Vector2 RetrieveObjPosition<T>(WorldState state, T obj) where T : SceneObj
        {
            Vector2 pos = GetPosition(state, GetObjNameKey(obj));
            obj.transform.position = pos.ToVector3();
            return pos;
        }

        public static string ObjDistanceKey<T, U>(T obj1, U obj2) where T : SceneObj where U : SceneObj
        {
            return ObjDistanceKey(GetObjNameKey(obj1), GetObjNameKey(obj2));
        }

        public static string ObjDistanceKey<T>(T obj1, string obj2Name) where T : SceneObj
        {
            return ObjDistanceKey(GetObjNameKey(obj1), obj2Name);
        }

        public static string ObjDistanceKey(string obj1Name, string obj2Name)
        {
            return $"Distance_{obj1Name}_{obj2Name}__";
        }

        public static float SaveDistanceToTarget<T, U>(WorldState state, T obj1, U obj2) where T : SceneObj where U : SceneObj
        {
            SaveObjPosition(state, obj1);
            SaveObjPosition(state, obj2);
            return SaveDistanceToTarget(state, GetObjNameKey(obj1), GetObjNameKey(obj2));
        }

        public static float SaveDistanceToTarget<T>(WorldState state, T obj1, string obj2Name) where T : SceneObj
        {
            SaveObjPosition(state, obj1);
            return SaveDistanceToTarget(state, GetObjNameKey(obj1), obj2Name);
        }

        public static float SaveDistanceToTarget(WorldState state, string obj1Name, string obj2Name)
        {
            string key1 = ObjDistanceKey(obj1Name, obj2Name);
            string key2 = ObjDistanceKey(obj2Name, obj1Name);
            Vector2 pos1 = GetPosition(state, obj1Name);
            Vector2 pos2 = GetPosition(state, obj2Name);
            float distance = Vector2.Distance(pos1, pos2);
            state.Set(key1, distance);
            state.Set(key2, distance);
            return distance;
        }
    }
}