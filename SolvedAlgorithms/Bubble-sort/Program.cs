using System.Globalization;

namespace ConsoleApp2
{
    class Bubble_Sortj
    {
        static void Main(string[] args)
        {
            int[] arr = { 27, 30, 45, 25, 19, 16, 12, 31, 2, 5, 3 };
            int temp; // container to hold element of the array
            int length = arr.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - (i + 1); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;

                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write(arr[i] + " "); // another procedure   foreach(int i in arr)
            }
        }
    }
}