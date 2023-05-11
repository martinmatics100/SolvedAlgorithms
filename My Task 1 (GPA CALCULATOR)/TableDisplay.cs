using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Task_1__GPA_CALCULATOR_
{
    internal class TableDisplay
    {
        public Course[] convertedGrades { get; set; }
        public double totalCourseUnitRegistered, totalCourseUnitPassed, totalWeightPoint, GPA;
        public TableDisplay(Course[] convertedGrades) 
        {
            this.convertedGrades = convertedGrades;
        }

        public double TotalCourseUnitRegistered() 
        {
            totalCourseUnitRegistered = 0;
            for (int i = 0; i < convertedGrades.Length; i++)
            {
                totalCourseUnitRegistered += convertedGrades[i].courseUnit;
            }
            return totalCourseUnitRegistered;
        }
        public double TotalWeightPoint()
        {
            totalWeightPoint = 0;
            for (int i = 0;i < convertedGrades.Length;i++)
            {
                totalWeightPoint += convertedGrades[i].weightPoint;
            }
            return totalWeightPoint;
        }

        public double Gpa() => GPA = Math.Round(TotalWeightPoint()  / TotalCourseUnitRegistered(), 2);

        public void Table()
        {
            Console.WriteLine();
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------|");
            Console.WriteLine("|  COUR SE & CODE  |  COURSE UNIT  |  GRADE  |  GRADE-UNIT  |  WEIGHT Pt.  |  REMARK   |");
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------|");

            foreach (var course in convertedGrades)
            {
                Console.WriteLine("|    " + course.courseCode + "   |   " + course.courseUnit + "   |   " + course.grade + "    |   " + course.gradeUnit + "    |   " + course.weightPoint.ToString().PadLeft(11, ' ') + "  |   " + course.remark.PadLeft(10, ' ') + "  |");
            } 
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------|");
            Console.WriteLine();
            Console.WriteLine($"Total Course Unit Registered is {TotalCourseUnitRegistered()}");
            //Console.WriteLine($"Total Course Unit Passed is {TotalCourseUnitPassed()}");
            Console.WriteLine($"Total Weight Point is {TotalWeightPoint()}");
            Console.WriteLine($"Your GPA is = {Gpa():F2} to 2 decimal places.");
        }

    }

 }
