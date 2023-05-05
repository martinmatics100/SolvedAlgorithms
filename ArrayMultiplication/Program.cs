using System.Runtime.InteropServices;

namespace ArrayMultiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare an array of numbers
            int[] arr = { 2, 5, 6, 9,10 };
            int product = 1; // initializing the product to be 1

            //looping through the array and multiplying each elememt with the product variable

            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            
            //printing the result
            Console.WriteLine("the product of the array is: " + product);

        }
    }
}