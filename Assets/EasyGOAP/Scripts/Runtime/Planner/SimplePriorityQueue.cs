using System;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.EasyGOAP
{
    // 非常低效 临时使用 后续替换
    public class SimplePriorityQueue<T>
    {
        private HashSet<T> set = new HashSet<T>();

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
    }
}
