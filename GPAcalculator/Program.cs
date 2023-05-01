namespace GPAcalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // course details
            string[,] courseDetails ={
                {"MTH101", "5", "B", "4" }, {"GS101", "3", "A", "5" }, {"NET101", "5", "C", "3" }, {"C#101", "5", "B", "4" }, {"HC101", "3", "F", "0" }
            };

            // grading system
            string[,] gradeSystem = {
                {"70-100", "A", "5", "Excellent"}, {"60-69", "B", "4", "Very Good"}, {"50-59", "C", "3", "Good"}, {"45-49", "D", "2", "Fair"}, {"40-44", "E", "1", "Pass"}, {"0-39", "F", "0", "Fail"}
            };

            // initialization

            int totalCourseUnit = 0;
            int totalCourseUnitPassed = 0;
            int totalWeightPoint = 0;

            Console.WriteLine("|--------------------|-------------------|------------|--------------|---------------|-----------| ");
            Console.WriteLine("|    COURSE & CODE   |   COURSE UNIT     |   GRADE    |  GRADE-UNIT  |   WEIGHT Pt.  |   REMARK  | ");
            Console.WriteLine("|--------------------|-------------------|------------|--------------|---------------|-----------| ");

            for (int i = 0; i < courseDetails.Length; i++)
            {
                string courseCode = courseDetails[i,0];
                int courseUnit = int.Parse(courseDetails[i,1]);
                string grade = courseDetails[i,2];
                int gradeUnit = int.Parse(gradeUnit(grade, gradeSystem));
                int weightPoint = courseUnit * gradeUnit;
                string remark = remark(grade, gradeSystem);

                Console.WriteLine($"| {courseCode,-18} | {courseUnit,-17} | {grade,-10} | {gradeUnit,-12} | {weightPoint,-13} | {remark,-9} | ");
                totalCourseUnit += courseUnit;


            }


        }
    }
}
  
            
            
            
            
            
            
            
            



            //      {
            //course data definitions
            //string[] courseCodes = { "MTH101", "GS101", "NET101", "C#101", "HC101"  };
         //   int[] courseUnits = { 5, 3, 5, 5, 3 };
           // string[] grades = { "B", "A", "C", "B", "F" };
           // int[] gradeUnits = { 4, 5, 3, 4, 5 };

            // initialize total-grade-units and total-weight-points
            //int totalGradeUnits = 0;
            //int totalWeightPoints = 0;

            //calculate weight points
            //for (int i = 0; i < courseCodes.Length; i++)
            //{
              //  int weightPoints = courseUnits[i] * gradeUnits[i];
              //  totalGradeUnits += courseUnits[i];
              //  totalWeightPoints += weightPoints;
           // }

            //calculate GPA

            //double gpa = (double)totalWeightPoints / totalGradeUnits;

            // table display
           // Console.WriteLine("|--------------------|-------------------|------------|--------------|---------------|-----------| ");
           //Console.WriteLine("|    COURSE & CODE   |   COURSE UNIT     |   GRADE    |  GRADE-UNIT  |   WEIGHT Pt.  |   REMARK  | ");
           // Console.WriteLine("|--------------------|-------------------|------------|--------------|---------------|-----------| ");
           
            //for (int i = 0; i < courseCodes.Length; i++)
            //{
            // string remark = GetRemark(grades[i]);
             //int weightPoint = courseUnits[i] * gradeUnits[i];

             //Console.WriteLine($"| {courseCodes[i],-18} | {courseUnits[i],-17} | {grades[i],-10} | {gradeUnits[i],-12} | {weightPoint,-13} | {remark, -9} | ");
            //}
            //Console.WriteLine("|------------------------------------------------------------------------------------------------|");

            // summary of info
            //Console.WriteLine($"\nTotal Course Unit Registered is {totalGradeUnits}");
            //Console.WriteLine($"\nTotal Course Unit Passed is {(grades, courseUnits)}");
            //Console.WriteLine($"\nTotal weight point is {totalWeightPoints}");
            //Console.WriteLine($"\nYour GPA = {gpa: F2} to 2 decimal places.");
        //}
          //  static string GetRemark(string grade)
        //{
          //  switch(grade)
            //{
              //  case "A":
            //        return "Excellent";
              //  case "B":
               //     return "Very Good";
                //case "C":
                  //  return "Good";
                //case "D":
                  //  return "Pass";
                //case "E":
                  //  return "Fair";
                //default:
                  //  return "Fail";



            //}
        //}
        //private static int GetTotalPassedUnits(string[] grades, int[] courseUnits)
        //{
          //  int totalPassedUnits = 0;
            //for (int i = 0;i < grades.Length;i++)
            //{
              //  if (grades[i] != "F")
                //{ 
                //totalPassedUnits += courseUnits[i]};
            //}
        //}
        //return totalPassedUnits;
    //}
//}