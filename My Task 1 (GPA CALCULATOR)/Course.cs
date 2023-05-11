using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Task_1__GPA_CALCULATOR_
{
    internal class Course
    {
        //attributes or fields of the class (course)
        public string courseCode, remark;
        public long courseScore;
        public char grade;
        public double courseUnit, gradeUnit, weightPoint;

        //constructors
        public Course(string courseCode, double courseUnit, long courseScore)
        {
            this.courseCode = courseCode;
            this.courseUnit = courseUnit;
            this.courseScore = courseScore;

            //setting grade Unit section
                if (courseScore >= 70 && courseScore <= 100)
                {
                    grade = 'A';
                    gradeUnit = 5;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Excellent";
                }
                else if (courseScore >= 60 && courseScore <= 69)
                {
                    grade = 'B';
                    gradeUnit = 4;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Very Good";
                }
                else if (courseScore >= 50 && courseScore <= 59)
                {
                    grade = 'C';
                    gradeUnit = 3;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Good";
                }
                else if (courseScore >= 45 && courseScore <= 49)
                {
                    grade = 'D';
                    gradeUnit = 2;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Fair";
                }
                else if (courseScore >= 40 && courseScore <= 44)
                {
                    grade = 'E';
                    gradeUnit = 1;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Pass";
                }
                else if (courseScore >= 0 && courseScore <= 39)
                {
                    grade = 'F';
                    gradeUnit = 0;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Fail";
                }
                else
                {
                   remark = "ivalid input";
                }
        }
    }
}
