using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2_TASK_GENERIC_CLASSES
{
    public class Stack<T>
    {
        private LinkedList<T> linkedList;

        public Stack()
        {
            linkedList = new LinkedList<T>();
        }

        public bool IsEmpty()
        {
            return linkedList.Count == 0;
        }

        public void Push(T item)
        {
            linkedList.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            T item = linkedList.tail.Data;
            linkedList.Remove(item);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return linkedList.tail.Data;
        }

        public int Size()
        {
            return linkedList.Count;
        }
    }
}
