using System;
using System.Runtime.CompilerServices;

namespace GPA_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The GPA Calculator Console App");
            Console.Write("Enter number of courses offered: ");
            long length = Convert.ToInt64(Console.ReadLine());
            Course[] courseArray = new Course[length];
            bool input = true;
            int counter = 0;
            while (input)
            {

                for (int i = 0; i < length; i++)
                {
                    Console.Write($"Enter Course {i + 1} Code e.g MTS509, GNS243, EEE453:");
                    string courseCode = Console.ReadLine();
                    
                    Console.Write($"Enter Course {i + 1} Unit e.g 0-9:");
                    double courseUnit = Convert.ToDouble(Console.ReadLine());
                    
                    Console.Write($"Course {i + 1} Score e.g 0-100:");
                    double gradeUnit = Convert.ToDouble(Console.ReadLine());
                    
                    courseArray[i] = new Course(courseCode, courseUnit, gradeUnit);
                    counter++;
                }
                if (counter == length) { input = false; }
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
            Console.WriteLine("Your GPA is = " + GPA());

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