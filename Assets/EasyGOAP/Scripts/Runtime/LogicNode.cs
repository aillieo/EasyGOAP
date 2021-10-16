using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyGOAP
{
    public class LogicNode
    {
        public static int poolSize = 128;
        private static readonly Stack<LogicNode> pool = new Stack<LogicNode>();

        public static LogicNode Create()
        {
            if (pool.Count > 0)
            {
                return pool.Pop();
            }

            return new LogicNode();
        }

        public static void Recycle(LogicNode node)
        {
            node.state.properties.Reset();
            node.action = null;
            node.previous = null;
            node.g = 0;
            node.h = 0;

            if (pool.Count < poolSize)
            {
                pool.Push(node);
            }
        }

        private LogicNode()
        {
        }

        internal State state = new State();
        internal IAction action;

        internal LogicNode previous;
        internal float g;
        internal float h;
    }
}
