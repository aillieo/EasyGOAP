using System;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.EasyGOAP
{
    // 非常低效 临时使用 后续替换
    public class SimplePriorityQueue<T>
    {
        private readonly HashSet<T> set = new HashSet<T>();
        private readonly List<T> list = new List<T>();
        private bool dirty = true;

        public T Dequeue()
        {
            T item = Peek();
            list.RemoveAt(0);
            set.Remove(item);
            return item;
        }

        public T Peek()
        {
            Sort();
            return list[0];
        }

        public void Enqueue(T item)
        {
            if (set.Add(item))
            {
                list.Add(item);
                dirty = true;
            }
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool Contains(T item)
        {
            return set.Contains(item);
        }

        private void Sort()
        {
            if (dirty)
            {
                dirty = false;
                list.Sort();
            }
        }
    }
}
