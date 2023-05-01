namespace GPAcalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You\'re welcome to my GPA Calculator");

            // variable initialization
            int totalCourseUnit = 0;
            int totalGradeUnit = 0;
            int totalWeightPoint = 0;

            // table header
            Console.WriteLine("|-----------------------|----------------|-----------|---------------|---------------|----------------------| ");
            Console.WriteLine("|    COURSES AND CODE   |    COURSE UNIT |   GRADE   |   GRADE-UNIT  |   WEIGHT-pt.  |   REMARK             | ");
            Console.WriteLine("|-----------------------|----------------|-----------|---------------|---------------|----------------------| ");
            Console.WriteLine("|        MTH101         |----------------|-----------|---------------|---------------|----------------------| ");
            Console.WriteLine("|        GS101          |----------------|-----------|---------------|---------------|----------------------| ");
            Console.WriteLine("|        NET101         |----------------|-----------|---------------|---------------|----------------------| ");
            Console.WriteLine("|        C#101          |----------------|-----------|---------------|---------------|----------------------| ");
            Console.WriteLine("|        HC101          |----------------|-----------|---------------|---------------|----------------------| ");

            // adding course data's to the table

            AddCourseToTable("MTH101", 5, "B", 4, ref totalCourseUnit, ref totalGradeUnit, ref totalWeightPoint);
            AddCourseToTable("GS101", 3, "A", 5, ref totalCourseUnit, ref totalGradeUnit, ref totalWeightPoint);
            AddCourseToTable("NET101", 5, "C", 3, ref totalCourseUnit, ref totalGradeUnit, ref totalWeightPoint);
            AddCourseToTable("C#101", 5, "B", 4, ref totalCourseUnit, ref totalGradeUnit, ref totalWeightPoint);
            AddCourseToTable("HC101", 3, "F", 0, ref totalCourseUnit, ref totalGradeUnit, ref totalWeightPoint);

            // total footer
           
            // calculate and output the GPA

            double gpa = (double)totalWeightPoint / totalGradeUnit;
            Console.WriteLine($"\nTotal Course Unit Registered is {totalCourseUnit}");
            Console.WriteLine($"\nTotal Course Unit Passed is {totalGradeUnit}");
            Console.WriteLine($"\nTotal Weight Point is {totalWeightPoint}");
            Console.WriteLine($"\nYour GPA is = {gpa:F2} to 2 decimal places.");
        }
        static void AddCourseToTable(string courseCode, int courseUnit, string grade, int gradeUnit, ref int totalCourseUnit, ref int totalGradeUnit, ref int totalWeightPoint)
        {
            int weightPoint = gradeUnit * courseUnit;
            totalCourseUnit += courseUnit;

            if (grade != "F")
            {
                totalGradeUnit += courseUnit;
                totalWeightPoint += weightPoint;
            }
            string remark = getRemark(grade);
            Console.WriteLine($"|   {courseCode, - 14}    |   {courseUnit, - 13}    |   {grade, - 5}) |   {gradeUnit, - 11} |   {weightPoint, - 14}   |   {remark,--15}   |");

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
        }
            
    }
}