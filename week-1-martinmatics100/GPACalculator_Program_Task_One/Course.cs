using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator_Program_Task_One
{
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
