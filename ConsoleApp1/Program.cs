using System;

namespace print_the_index_of_the_last_occurrence_of_a_given_element_in_an_array
{
    internal class Program
    {
        static void lastOccurence(int[] args)
        {
            //You have been given an array consisting of integers. In addition you have been given an element,
            //you need to find and print the index of the last occurrence of this element in the array
            //if it exists in it, otherwise print -1.
            //Example
            //int nums = [1, 2, 3, 4, 1]
            //lastOccurance(nums, 1);    //  => 4
            //lastOccurance(nums, 10);    //  =>  -1

            int[] arr = { 1, 2, 3, 4, 1, 3 };
            int element = 3;
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