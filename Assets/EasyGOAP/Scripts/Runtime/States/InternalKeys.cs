using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public static class InternalKeys
    {
        public static readonly string targetPosition = "_target_position__";
        public static readonly string distanceToTarget = "_distance_to_target__";
        public static readonly string action = "_action__";
        public static readonly string actionResult = "_action_result__";

        public static void HashPosKey(string rawKey, out string xKey, out string yKey)
        {
            xKey = $"{rawKey}_pos_x__";
            yKey = $"{rawKey}_pos_y__";
        }
    }
}
