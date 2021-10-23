using AillieoUtils.FSM;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public static class IStateMachineExt
    {
        public static void SetVector2(this StateMachine stateMachine, string key, Vector2 value)
        {
            InternalKeys.HashPosKey(key, out string xKey, out string yKey);
            stateMachine.SetFloat(xKey, value.x);
            stateMachine.SetFloat(yKey, value.y);
        }

        public static Vector2 GetVector2(this StateMachine stateMachine, string key)
        {
            InternalKeys.HashPosKey(key, out string xKey, out string yKey);
            float x = stateMachine.GetFloat(xKey);
            float y = stateMachine.GetFloat(yKey);
            return new Vector2(x, y);
        }
    }
}
