﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2_TASK_GENERIC_CLASSES
{
    internal class Queue<T>
    {
        private LinkedList<T> linkedList;

        public Queue()
        {
            linkedList = new LinkedList<T>();
        }

        public bool IsEmpty()
        {
            return linkedList.Count == 0;
        }

        public void Enqueue(T item)
        {
            linkedList.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            T item = linkedList.head.Data;
            linkedList.Remove(item);
            return item;
        }

        public int Size()
        {
            return linkedList.Count;
        }
    }
}
