using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2_TASK_GENERIC_CLASSES
{
    public class LinkedList<T>
    {
        public class Node
        {

            public T Data;
            public Node Next;

            public Node(T data)
            {
                Data = data;
                Next = null!;
            }
        }

        public Node head = default!;
        public Node tail = default!;
        private int size;

        public int Size { get { return size; } }

        public int Add(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            size++;
            return size;
        }

        public bool Remove(T item)
        {
            Node current = head;
            Node previous = null!;

            while (current != null)
            {
                if (current.Data!.Equals(item))
                {
                    if (previous == null)
                    {
                        head = current.Next;
                        if (head == null)
                            tail = null!;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }

                    size--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool Check(T item)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data!.Equals(item))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public int Index(T item)
        {
            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Data!.Equals(item))
                    return index;

                current = current.Next;
                index++;
            }

            return -1;
        }
    }
}

