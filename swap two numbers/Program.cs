namespace SwapTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 7;
            //int b = 14;

            //// logic
            //int temp = a; // stored a as 7
            //a = b;
            //b = temp;

            //// result

            //Console.WriteLine($"a = {a} and b = {b}"); // result by interpolation
            //Console.WriteLine("a = " + a + " and b = " + b); // result by string concantenation

            Console.WriteLine(GetName("Ifunanya", "Chukwudi"));

            string fullName = GetName("Ifunanya", "Chukwudi");

            int fullName2 = GetName(89, 67);

            string fullName1 = GetName("Joe", "Doe");
            Console.WriteLine($"My full name is {fullName}");
            Console.WriteLine($"My full name is {fullName1}");
            Console.WriteLine($"My full name is {fullName2}");


        }

        public static string GetName(string firstName, string lastName)
        {
            return firstName;
        }
        public static int GetName(int age, int height)
        {
            return height;
            return age;
        }
    }
}