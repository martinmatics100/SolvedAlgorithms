using GPACalculator_Program_Task_One;
using System;
using System.Runtime.CompilerServices;

namespace GPA_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            string appMsg = "YOU'RE WELCOME TO THE GPA CALCULATOR CONSOLE APP. " +
                "\n To calculate your GPA, Enter your input as follows: " +
                "\n 2. Course Code e.g MTH123, ENG103, PHY134, GEO111. etc. " +
                "\n 3. Course Unit (0 - 5). " +
                "\n 4. Course Score (0 - 100). " +
                "\n\n\n\n";
            string numOfCourseMsg = $"Enter number of course(s) offered: ";

            string numOfCourseErrMsg = "Take note of the following: " +
                "\n 1. number of courses must be a number " +
                "\n 2. number of courses offered must be between the range (1 - 100). No negative integer " +
                "\n 3. number of courses can't be empty";

            string CourseCodeMsg =
                $"\n 1. please NOTE the following: " +
                $"\n 2. Course Code follows the format MTH123, ENG103, PHY134, GEO111. etc:" +
                $"\n 3. Course Code must not be more than six(6) characters (three letters and three numbers): " +
                $"\n 4. Course Code can't be empty: " +
                $"\n 5. A Course Code can't be entered more than once";

            string courseUnitErrMsg = $"Invalid input: " +
                $"\n please Note" +
                $"\n Course Unit must be between the range (0 - 5)\n ";

            string courseScoreMsg = $"Invalid input: " +
                $"please Note" +
                $"\n Course Unit must be between the range (0 - 100)\n ";

            Console.WriteLine();
            Console.WriteLine(appMsg);
            Console.WriteLine(numOfCourseMsg);
            string numOfCourse = Console.ReadLine();

           
            byte length;
            while (!byte.TryParse(numOfCourse, out length) || length < 1 || length > 100)
            {
                Console.WriteLine(numOfCourseErrMsg);
                numOfCourse = Console.ReadLine();
            }

            Course[] courseArray = new Course[length];
            bool input = true;
            int counter = 0;
            while (input)
            {
                for (int i = 0; i < courseArray.Length; i++)
                {
                    Console.WriteLine($"Enter Course {i + 1} Code e.g MTH123, ENG103, PHY134, GEO111");
                    String courseCodeInput = Console.ReadLine();
                    string courseCode;

                    Validator check = new Validator(courseArray);
                    while (!check.Match(courseCodeInput) || check.Exist(courseCodeInput.ToUpper()))
                    {
                        Console.WriteLine(CourseCodeMsg + $"\n\n\n Enter Course {i + 1} code: ");
                        courseCodeInput = Console.ReadLine();
                    }
                    courseCode = courseCodeInput.ToUpper();
                    Console.WriteLine($"Enter Course {i + 1} Unit within the range (0 - 5): ");
                    string courseUnitInput = Console.ReadLine();
                    long courseUnit;

                    while (!long.TryParse(courseUnitInput, out courseUnit) || courseUnit < 0 || courseUnit > 5)
                    {
                        Console.WriteLine(courseUnitErrMsg + $"Enter Course {i + 1} Unit: ");
                        courseUnitInput = Console.ReadLine();
                    }

                    Console.WriteLine($"Course {1 + 1} Score between the range (0 - 100): ");
                    string courseScoreInput = Console.ReadLine();
                    long courseScore;
                    while (!long.TryParse(courseScoreInput, out courseScore) || courseScore < 0 || courseScore > 100)
                    {
                        Console.WriteLine(courseScoreMsg + $"Enter Course {i + 1} score: ");
                        courseScoreInput = Console.ReadLine();
                    }
                    courseArray[i] = new Course(courseCode, courseUnit, courseScore);
                    counter++;
                    Console.Clear();
                }
                if (counter == length)
                {
                    input = false;
                }
            }
                    TableDisplay resultDisplay = new TableDisplay(courseArray);
                    resultDisplay.Table();
                    Console.ReadKey();
        }
    }  
}