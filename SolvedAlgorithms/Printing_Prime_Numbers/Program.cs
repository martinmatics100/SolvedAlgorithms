using System;

namespace Printing_Prime_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nums = 2000;
            for (int i = 2; i < nums; i++) 
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine("{0} ", i);
                }
            }

        }
    }
}