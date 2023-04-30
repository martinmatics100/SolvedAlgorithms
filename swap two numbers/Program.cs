namespace SwapTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
        int a = 7;
        int b = 14;

        // logic
        int temp = a; // stored a as 7
        a = b;
        b = temp;

        // result

        Console.WriteLine($"a = {a} and b = {b}"); // result by interpolation
        Console.WriteLine("a = " + a + " and b = " + b); // result by string concantenation
        }
    }
}