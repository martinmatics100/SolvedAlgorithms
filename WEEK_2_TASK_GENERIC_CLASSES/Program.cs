namespace WEEK_2_TASK_GENERIC_CLASSES
{
    internal class Program
    {
        static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(30);
            linkedList.Add(40);
            linkedList.Add(50);
            linkedList.Add(60);

            Console.WriteLine();
            Console.WriteLine("  |--------------------|");
            Console.WriteLine("  | SINGLY LINKED LIST |");
            Console.WriteLine("  |--------------------|");
            Console.WriteLine();
            Console.WriteLine("  List Size: " + linkedList.Add(70)); //output == 7
            Console.WriteLine("  List Size: " + linkedList.Add(80)); //output == 8
            Console.WriteLine();

            Console.WriteLine("  Removed: " + linkedList.Remove(60)); //output == true
            Console.WriteLine("  Removed: " + linkedList.Remove(60)); //output == false
            Console.WriteLine();

            Console.WriteLine("  Check: " + linkedList.Check(50)); // output == true
            Console.WriteLine("  Check: " + linkedList.Check(95)); // output == false
            Console.WriteLine();

            Console.WriteLine("  Index: " + linkedList.Index(40));  // output == 3
            Console.WriteLine("  Index: " + linkedList.Index(85));  // output == -1
            Console.WriteLine();
            Console.WriteLine();

            Stack<int> stack = new Stack<int>();

            Console.WriteLine("  |---------|");
            Console.WriteLine("  |  STACK  |");
            Console.WriteLine("  |---------|");
            Console.WriteLine();
            Console.WriteLine("  Stack is empty = " + stack.IsEmpty());  // output == true

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(50);
            stack.Push(60);
            stack.Push(70);

            
            Console.WriteLine("  Stack is Empty = " + stack.IsEmpty()); // output == false
            Console.WriteLine();

            Console.WriteLine("  Stack size = " + stack.Size());  // output == 6
            Console.WriteLine();

            Console.WriteLine("  Returned last item added to the stack which is = " + stack.Peek()); // output == 70
            Console.WriteLine();

            Console.WriteLine("  Removed last item added to the stack which is = " + stack.Pop());  // output == 70
            Console.WriteLine();

            Console.WriteLine("  Returned last item added to the stack which is = " + stack.Peek()); // output == 60 because 70 has been removed by the pop method
            Console.WriteLine();

            Queue<int> queue = new Queue<int>();

            Console.WriteLine("  |----------|");
            Console.WriteLine("  |  QUEUE   |");
            Console.WriteLine("  |----------|");
            Console.WriteLine();

            Console.WriteLine("  Is Queue empty = " + queue.IsEmpty());    // Output: true

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);

            Console.WriteLine("  Is Queue empty = " + queue.IsEmpty());    // Output: false
            Console.WriteLine();

            Console.WriteLine("  Queue Size = " + queue.Size());       // Output: 5
            Console.WriteLine();

            Console.WriteLine("  Removed first item added which is = " + queue.Dequeue());    // Output: 10
            Console.WriteLine();

            Console.WriteLine("  Queue size after the Dequeue method = " + queue.Size());       // Output: 4

           
        }
    }
}