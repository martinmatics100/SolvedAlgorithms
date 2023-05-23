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
                "\n 3. Course Unit (0 - 9). " +
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
                $"\n Course Unit must be between the range (0 - 6)\n ";

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
                    Console.WriteLine($"Enter Course {i + 1} Unit within the range (0 - 6): ");
                    string courseUnitInput = Console.ReadLine();
                    long courseUnit;

                    while (!long.TryParse(courseUnitInput, out courseUnit) || courseUnit < 0 || courseUnit > 6)
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

    
    
    class TableDisplay
    {
        public Course[] convertedGrades { get; set; }
        public double tCUregister, tCUpassed, tWpoint, gPA;
        public TableDisplay(Course[] convertedGrades)
        {
            this.convertedGrades = convertedGrades;
        }

        public double TCUregister()
        {
            tCUregister = 0;
            for (int i = 0; i < convertedGrades.Length; i++)
            {
                tCUregister += convertedGrades[i].courseUnit;
            }
            return tCUregister;
        }

        public double TCUpassed()
        {
            tCUpassed = 0;
            for (int i = 0; i < convertedGrades.Length; i++)
            {
                if (convertedGrades[i].gradeUnit != 0)
                {
                    tCUpassed += convertedGrades[i].courseUnit;
                }
            }
            return tCUpassed;
        }

        public double TWpoint()
        {
            tWpoint = 0;
            for (int i = 0; i < convertedGrades.Length; i++)
            {
                tWpoint += convertedGrades[i].weightPoint;
            }
            return tWpoint;
        }

        public double GPA() => Math.Round(TWpoint() / TCUregister(), 2);


        public void Table()
        {
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-----------|");
            Console.WriteLine("| COURSE & CODE | COURSE UNIT | GRADE | GRADE-UNIT | WEIGHT Pt. |  REMARK   |");
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-----------|");

            foreach (var course in convertedGrades)
            {
                Console.WriteLine("|    " + course.courseCode + "     |      " + course.courseUnit + "      |   " + course.grade + "   |       " + course.gradeUnit + "    |" + course.weightPoint.ToString().PadLeft(11, ' ') + " | " + course.remarks.PadLeft(10, ' ') + "|");
            }
            Console.WriteLine("|--------------------------------------------------|------------|-----------|");
            Console.WriteLine();
            Console.WriteLine("Total Course Unit Registered is " + TCUregister());
            Console.WriteLine();
            Console.WriteLine("Total Course Unit Passed is " + TCUpassed());
            Console.WriteLine();
            Console.WriteLine("Total Weight Point is " + TWpoint());
            Console.WriteLine();
            Console.WriteLine($"Your GPA is {GPA():F2} to 2 decimal places.");

        }


    }

    
    
    class Course
    {
        // Fields
        public string courseCode, grade, remarks;
        public double courseUnit, gradeUnit, weightPoint, courseScore;

        // Constructors
        public Course(string courseCode, double courseUnit, double courseScore)
        {
            this.courseCode = courseCode;
            this.courseUnit = courseUnit;
            this.courseScore = courseScore;

            // set grade unit category
            this.gradeUnit = courseScore >= 0 && courseScore < 40 ? 0 :
                courseScore >= 40 && courseScore < 45 ? 1 :
                courseScore >= 45 && courseScore < 50 ? 2 :
                courseScore >= 50 && courseScore < 60 ? 3 :
                courseScore >= 60 && courseScore < 70 ? 4 :
                courseScore >= 70 && courseScore <= 100 ? 5 : 6;

            // set grade category
            this.grade = gradeUnit == 5 ? "A" : gradeUnit == 4 ? "B" : gradeUnit == 3 ? "C" :
            gradeUnit == 2 ? "D" : gradeUnit == 1 ? "E" : gradeUnit == 0 ? "F" : "No Grade";

            // calculate Weight Point
            this.weightPoint = courseUnit * gradeUnit;

            // set remarks category
            this.remarks = gradeUnit == 5 ? "Excellent" : gradeUnit == 4 ? "Very Good" : gradeUnit == 3 ? "Good" :
            gradeUnit == 2 ? "Fair" : gradeUnit == 1 ? "Poor" : gradeUnit == 0 ? "Fail" : "No Remarks";

        }

    }
}