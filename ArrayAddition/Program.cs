namespace SumOfArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declare an array
            int[] nums = { 1, 2, 3, 5, 7, 4, 3};
            int addition = 0;

            // loopin through the array to add  each element to addition
            for (int i = 0; i < nums.Length; i++)
            {
                addition += nums[i];
            }
            //printing the result
            Console.WriteLine( "The sum of the array is: " + addition);
        }
    }
}