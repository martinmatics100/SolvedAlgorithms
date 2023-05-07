using System.Dynamic;

namespace GPAcalculator_Task_1 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO MY GPA CALCULATOR");

            Console.WriteLine("Enter The Number Of Courses Offered");
            int numOfCourses = int.Parse(Console.ReadLine());
             
            //course data initialization
            string courseCodes; 
            int courseUnit;
            char grade;
            int gradeUnit;
            int weightPoint;
            string remark;
            int courseScores;
            string sum = "";
            int totalCourseUnitRegistered = 0;
            int totalCourseUnitPassed = 0;
            int totalWeightPoint = 0;

            //prompt user to enter course codes, course unit, course score
            int counter = 1;
            for (int i = 0; i < numOfCourses; i++)
            {
                Console.WriteLine("Enter the course code for course:");
                courseCodes = Console.ReadLine();

                Console.WriteLine("Enter the course unit for course");
                courseUnit = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the course score for course " + (i + 1) + " ");
                courseScores = int.Parse(Console.ReadLine());

                if ( courseScores >= 70 && courseScores <= 100 )
                {
                    grade = 'A';
                    gradeUnit = 5;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Excellent";
                }
                else if ( courseScores >= 60 && courseScores <= 69 )
                {
                    grade = 'B';
                    gradeUnit = 4;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Very Good";
                }
                else if ( courseScores >= 50 &&  courseScores <= 59)
                {
                    grade = 'C';
                    gradeUnit = 3;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Good";
                }
                else if ( courseScores >= 45 && courseScores <= 49)
                {
                    grade = 'D';
                    gradeUnit = 2;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Fair";
                }
                else if ( courseScores >= 40 && courseScores <= 44)
                {
                    grade = 'E';
                    gradeUnit = 1;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Pass";
                }
                else if ( courseScores >=0 &&  courseScores <=39)
                {
                    grade = 'F';
                    gradeUnit = 0;
                    weightPoint = courseUnit * gradeUnit;
                    remark = "Fail";
                }
                else
                {
                    Console.WriteLine("Invalid input entered");
                    break;
                }
                sum = sum + $"| {courseCodes, -15} | {courseUnit, -13} | {grade, -7} | {gradeUnit, -12} | {weightPoint, -12} | {remark, -9} |\n";
                counter++;
                totalCourseUnitRegistered += courseUnit;
                if (grade != 'F')
                {
                    totalCourseUnitPassed += courseUnit;
                }
                totalWeightPoint += weightPoint;
            }
            double gpa = totalWeightPoint / totalCourseUnitRegistered;

            //Display table
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------| ");
            Console.WriteLine("|  COURSE & CODE  |  COURSE UNIT  |  GRADE  |  GRADE-UNIT  |  WEIGHT Pt.  |  REMARK   | ");
            Console.WriteLine("|-----------------|---------------|---------|--------------|--------------|-----------| ");
            Console.WriteLine($"{sum}\n\n\n");
            Console.WriteLine($"Total Course Unit Registered is {totalCourseUnitRegistered}");
            Console.WriteLine($"Total Course Unit Passed is {totalCourseUnitPassed}");
            Console.WriteLine($"Total Weight Point is {totalWeightPoint}");
            Console.WriteLine($"Your GPA is = {gpa:F2} to 2 decimal places."); 

        }
    }
}