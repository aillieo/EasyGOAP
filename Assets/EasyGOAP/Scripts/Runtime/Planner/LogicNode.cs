using System;
using System.Collections.Generic;

namespace AillieoUtils.EasyGOAP
{
    public class LogicNode : IComparable<LogicNode>
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
            node.state.Reset();
            node.action = null;
            node.previous = null;
            node.g = 0;
            node.h = 0;

            if (pool.Count < poolSize)
            {
                pool.Push(node);
            }
        }

        public int CompareTo(LogicNode other)
        {
            return (g + h).CompareTo(other.g + other.h);
        }

        private LogicNode()
        {
        }

        internal readonly WorldState state = new WorldState();
        internal IAction action;

        internal LogicNode previous;
        internal float g;
        internal float h;
    }
}
