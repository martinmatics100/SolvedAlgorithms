using System;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // course data definition
            string[] courseCodes = { "MTH101", "GS101", "NET101", "C#101", "HC101" };
            int[] courseUnits = { 5, 3, 5, 5, 3 };
            string[] grades = { "B", "A", "C", "B", "F" };
            int[] gradeUnits = { 4, 5, 3, 4, 0 };

            // weight points and total grade units calculation
            int totalGradeUnits = 0;
            int totalWeightPoints = 0;
            for (int i = 0; i < courseCodes.Length; i++)
            {
                int weightPoint = courseUnits[i] * gradeUnits[i];
                totalGradeUnits += courseUnits[i];
                totalWeightPoints += weightPoint;
            }

            // GPA calculation
            double gpa = (double)totalWeightPoints / totalGradeUnits;

            // Display table
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------| ");
            Console.WriteLine("|  COURSE & CODE  |  COURSE UNIT  |  GRADE  |  GRADE-UNIT  |  WEIGHT Pt.  |  REMARK   | ");
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------| ");
            for (int i = 0; i < courseCodes.Length; i++)
            {
                string remark = GetRemark(grades[i]);
                int weightPoint = courseUnits[i] * gradeUnits[i];
                Console.WriteLine($"| {courseCodes[i],-15} | {courseUnits[i],-13} | {grades[i],-7} | {gradeUnits[i],-12} | {weightPoint,-12} | {remark,-10}| ");
            }
            Console.WriteLine("|----------------|----------------|---------|--------------|--------------|-----------| ");

            // Display summary
            Console.WriteLine($"\nTotal Course Unit Registered is {totalGradeUnits}");
            Console.WriteLine($"Total Course Unit Passed is {GetTotalPassedUnits(grades, courseUnits)}");
            Console.WriteLine($"Total Weight Point is {totalWeightPoints}");
            Console.WriteLine($"Your GPA is = {gpa:F2} to 2 decimal places.");
        }

        static string GetRemark(string grade)
        {
            switch (grade)
            {
                case "A":
                    return "Excellent";
                case "B":
                    return "Very Good";
                case "C":
                    return "Good";
                case "D":
                case "E":
                    return "Fair";
                default:
                    return "Fail";
            }
        }

        static int GetTotalPassedUnits(string[] grades, int[] courseUnits)
        {
            int totalPassedUnits = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] != "F")
                {
                    totalPassedUnits += courseUnits[i];
                }
            }
            return totalPassedUnits;
        }
    }
}
