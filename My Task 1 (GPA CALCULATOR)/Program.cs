using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace My_Task_1__GPA_CALCULATOR_
{
    internal class Program
    {
        static void Main()
        {
            string appMsg = "You're welcome to the GPA Calculator console app. " +
                "\n To calculate your GPA, Enter your input as follows: " +
                "\n 1. Course Code must be in UPPER CASE" +
                "\n 2. Course Code e.g MTH123, ENG103, PHY134, GEO111. etc. " +
                "\n 3. Course Unit (0 - 9). " +
                "\n 4. Course Score (0 - 100). " +
                "\n\n\n\n";

            string numOfCourseMsg = $"Enter number of course(s) offered: ";

            string numOfCourseErrMsg = $"Wrong input, Please enter a number: ";

            string CourseCodeMsg = $"Invalid input: " +
                $"\n please NOTE the following: " +
                $"\n Course Code format MTH123, ENG103, PHY134, GEO111. etc:" +
                $"\n Course Code must not be more than six(6) characters: " +
                $"\n Course Code can't be empty: " +
                $"\n A Course Code can't be entered more than once";

            string courseUnitErrMsg = $"Invalid input: " +
                $"\n please Note" +
                $"\n Course Unit must be between the range (0 - 9)\n ";

            string courseScoreMsg = $"Invalid input: " +
                $"please Note" +
                $"\n Course Unit must be between the range (0 - 100)\n ";

            Console.WriteLine();
            Console.WriteLine(appMsg);
            Console.WriteLine(numOfCourseMsg);
            string numOfCourse = Console.ReadLine()!;

            long length;
            while (!long.TryParse(numOfCourse, out length) || length < 1 || length > 100)
            {
                Console.WriteLine(numOfCourseErrMsg);
                numOfCourse = Console.ReadLine()!;
            }

            Course[] courseArray = new Course[length];
            bool input = true;
            int counter = 0;
            while (input)
            {
                for (int i = 0; i < courseArray.Length; i++)
                {
                    Console.WriteLine($"Enter Course {i + 1} Code e.g MTH123, ENG103, PHY134, GEO111");
                    String courseCodeInput = Console.ReadLine()!;
                    string courseCode;

                    Validator check = new Validator(courseArray)!;

                    while (!check.Match(courseCodeInput!) || !check.Exist(courseCodeInput!) || check.Exist(courseCodeInput!.ToUpper()))
                    {
                        Console.WriteLine(CourseCodeMsg + $"Enter Course{i + 1} code: ");
                        courseCodeInput = Console.ReadLine()!;
                    }

                    courseCode = courseCodeInput.ToUpper();
                    Console.WriteLine($"Enter Course {i + 1} Unit within the range (0 - 9): ");
                    string courseUnitInput = Console.ReadLine()!;
                    long courseUnit;

                    while (!long.TryParse(courseUnitInput, out courseUnit) ||  courseUnit < 0 || courseUnit > 9)
                    {
                        Console.WriteLine(courseUnitErrMsg + $"Enter Course {i + 1} Unit: ");
                        courseUnitInput = Console.ReadLine()!;
                    }

                    Console.WriteLine($"Course {1 + 1} Score between the range (0 - 100): ");
                    string courseScoreInput = Console.ReadLine()!;
                    long courseScore;
                    while (!long.TryParse(courseScoreInput, out courseScore) || courseScore < 0 || courseScore > 100)
                    {
                        Console.WriteLine(courseScoreMsg + $"Enter Course {i + 1} score: ");
                        courseScoreInput = Console.ReadLine()!;
                    }
                    courseArray[i] = new Course(courseCode, courseUnit, courseScore);
                    counter ++;  
                    Console.Clear();
                }
                if (counter == length)
                {
                    input = false;
                }

                TableDisplay resultDisplay = new TableDisplay(courseArray)!;
                Console.WriteLine();
                resultDisplay.Table();
            }


        }
    }
}