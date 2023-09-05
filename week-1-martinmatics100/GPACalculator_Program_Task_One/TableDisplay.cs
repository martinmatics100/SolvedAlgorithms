using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator_Program_Task_One
{
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
}
