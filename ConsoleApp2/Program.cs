namespace printIndexOfLastOccurence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You have been given an array consisting of integers.
            //In addition you have been given an element,
            //you need to find and print the index of the last occurrence
            //of this element in the array if it exists in it, otherwise print -1.

            //

            int[] arr = { 1, 2, 3, 4, 5, 6, 3, 2, 5, 4, 5, 6, 4, 5 };
            int element = 4;
            int lastIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    lastIndex = i;
                }
            }
            Console.WriteLine(lastIndex);
        }
    }
}