namespace GPAcalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //course data definitions
            string[] courseCodes = { "MTH101", "GS101", "NET101", "C#101", "HC101"  };
            int[] courseUnits = { 5, 3, 5, 5, 3 };
            string[] grades = { "B", "A", "C", "B", "F" };
            int[] gradeUnits = { 4, 5, 3, 4, 5 };

            // initialize total-grade-units and total-weight-points
            int totalGradeUnits = 0;
            int totalWeightPoints = 0;

            //calculate weight points
            for (int i = 0; i < courseCodes.Length; i++)
            {
                int weightPoints = courseUnits[i] * gradeUnits[i];
                totalGradeUnits += courseUnits[i];
                totalWeightPoints += weightPoints;
            }

            //calculate GPA

            double gpa = (double)totalWeightPoints / totalGradeUnits;

            // table display
            Console.WriteLine("|--------------------|-------------------|------------|--------------|---------------|-----------| ");
            Console.WriteLine("|    COURSE & CODE   |   COURSE UNIT     |   GRADE    |  GRADE-UNIT  |   WEIGHT Pt.  |   REMARK  | ");
            Console.WriteLine("|--------------------|-------------------|------------|--------------|---------------|-----------| ");
            for (int i = 0; i < courseCodes.Length; i++)
            {
             string remark = GetRemark(grades[i]);
             int weightPoint = courseUnits[i] * gradeUnits[i];
             Console.WriteLine($"| {courseCodes[i],-18} | {courseUnits[i],-17} | {grades[i],-10} | {gradeUnits[i],-12} | {weightPoint,-13} | {remark, -9} | ");
            }
            Console.WriteLine("|--------------------|-------------------|------------|--------------|---------------|------------|");




        }
            
    }
}