using System;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of courses offered:");
            int numOfCourses = int.Parse(Console.ReadLine());
            
            string[] courseCodes = new string[numOfCourses];
            int[] courseUnits = new int[numOfCourses];
            string[] grades = new string[numOfCourses];
            int[] gradeUnits = new int[numOfCourses];
            
            // Prompt user to input course code, course unit, and grade unit for each course
            for (int i = 0; i < numOfCourses; i++)
            {
                Console.WriteLine("Enter course code for course " + (i + 1) + ":");
                courseCodes[i] = Console.ReadLine();

                Console.WriteLine("Enter course unit for course " + (i + 1) + ":");
                courseUnits[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter grade for course " + (i + 1) + " (A, B, C, D, E, or F):");
                grades[i] = Console.ReadLine();

                Console.WriteLine("Enter grade unit for course " + (i + 1) + ":");
                gradeUnits[i] = int.Parse(Console.ReadLine());
            }

            // Calculate total weighted points and total course units
            int totalWeightedPoints = 0;
            int totalCourseUnits = 0;
            for (int i = 0; i < numOfCourses; i++)
            {
                int weightedPoints = GetWeightedPoints(grades[i]) * gradeUnits[i];
                totalWeightedPoints += weightedPoints;
                totalCourseUnits += courseUnits[i];
            }

            // Calculate GPA
            double gpa = (double)totalWeightedPoints / totalCourseUnits;

            // Print result in tabular form
            Console.WriteLine("|----------------------------|-----------------------|------------|---------------------|-------------------|-------------------|");
            Console.WriteLine("| COURSE & CODE             | COURSE UNIT           | GRADE      | GRADE-UNIT          | WEIGHT Pt.        | REMARK            |");
            Console.WriteLine("|----------------------------|-----------------------|------------|---------------------|-------------------|-------------------|");

            for (int i = 0; i < numOfCourses; i++)
            {
                int weightedPoints = GetWeightedPoints(grades[i]) * gradeUnits[i];
                string remark = GetRemark(grades[i]);

                Console.WriteLine("| {0,-25} | {1,-21} | {2,-10} | {3,-19} | {4,-17} | {5,-17} |",
                    courseCodes[i], courseUnits[i], grades[i], gradeUnits[i], weightedPoints, remark);
            }

            Console.WriteLine("|---------------------------------------------------------------------------------------|------------------|-------------------|");
            Console.WriteLine("| Total Course Units: {0,-57} | {1,-17:F2} |", totalCourseUnits, gpa);
            Console.WriteLine("|---------------------------------------------------------------------------------------|------------------|-------------------|");
        }

        // Returns the weighted point based on the grade
        static int GetWeightedPoints(string grade)
        {
            switch (grade.ToUpper())
            {
                case "A":
                    return 5;
                case "B":
                    return 4;
                case "C":
                    return 3;
                case "D":
                    return 2;
                case "E":
                    return 1;
                default:
                    return 0;
            }
        }

        // Returns the remark based on the grade
        static string GetRemark(string)
    }
}
