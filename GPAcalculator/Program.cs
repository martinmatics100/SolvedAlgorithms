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
                double weightPoint = 0;
                switch (courseGrade)
                {
                    case "A":
                        weightPoint = 5.0;
                        break;
                    case "B":
                        weightPoint = 4.0;
                        break;
                    case "C":
                        weightPoint = 3.0;
                        break;
                    case "D":
                        weightPoint = 2.0;
                        break;
                    case "E":
                        weightPoint = 1.0;
                        break;
                    case "F":
                        weightPoint = 0.0;
                        break;
                        Console.WriteLine("invalid input. Please input A,B,C,D,E or F. ");
                        i--; // decreement i to run current iteration again
                        continue; //skip the remaining current iteration

                        // add to total grade unit and weight points
                        totalCourseUnit += courseUnit;
                        totalWeightPoint += weightPoint * courseUnit;

                        // calculate GPA and display result.

                        double gpa = totalWeightPoint / courseUnit;
                        Console.WriteLine("Your GPA is " + gpa.ToString(F2));

                        Console.WriteLine("press any key to exit. ");
                        Console.ReadKey();




                }

            }
        }
    }
}