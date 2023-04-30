namespace GPAcalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You\'re welcome to my GPA Calculator");

            // user should iput the number of courses taken
            Console.WriteLine("input the number of course taken");
            int no_Of_Courses = int.Parse(Console.ReadLine());

            // totalGradeUnit and totalWeightPoint are all initialized that is = 0
            int totalGradeUnit = 0;
            double totalWeightPoint = 0;

            //looping through the courses and requesting user to input course grade and grade unit.
            for (int i = 0; i <= no_Of_Courses; i++)
            {
                Console.WriteLine("input your course grade and grade points for course " +  i + ":");
                Console.Write("Course grade (A,B,C,D,E,F): ");
                string courseGrade = Console.ReadLine();
                Console.Write("course Unit: ");
                int courseUnit = int.Parse(Console.ReadLine());

                //calculating grade point based on course grade

            }
        }
    }
}