namespace StringDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
           // StringConversion();
            //StringAsArray();
            //EscapeString();
            //AppendingString();
            InterpolationAndLiterals();
        }

        public static void StringConversion()
        {
            string testString = "tHIs iS My naME";
            string result = testString.ToUpper();
            Console.WriteLine(result);

            string answer = testString.ToLower();
            Console.WriteLine(answer);
        }

        public static void StringAsArray()
        {
            string testString = "Martin";
            for (int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine(i + ": " + testString[i]);
            }
        }

        public static void EscapeString()
        {
            string results = "This is my \"Test\" solution";
            Console.WriteLine(results);

            results = "C: \\Demo\\Martin\\txt'";
            Console.WriteLine(results);

            results = @"C: \Demo\\Martin\txt'";
            Console.WriteLine(results);

        }

        public static void AppendingString()
        {
            string firstName = "Martin";
            string lastName = "Nwatu";
            string middleName = "Chukwuemeka";
            string results;
            results = firstName + ", my name is " + firstName + " " + lastName + " " + middleName ;
            Console.WriteLine(results);

            results = string.Format("{0}, my name is {0} {1} {2}", firstName, lastName, middleName);
            Console.WriteLine(results);

            results = $"{firstName}, my name is {firstName} {lastName} {middleName}";
            Console.WriteLine(results);
        }

        public static void InterpolationAndLiterals()
        {
            string testString = "Martin Nwatu";
            string results = $@"C: \Demo\{testString}\{"\""}Text{"\""}.txt"; //order of arrangement does not matter $@ will give same output as @$.
            Console.WriteLine(results);
        }

        public static void stringBuilderDemo()
        {

        }
            
    }
}