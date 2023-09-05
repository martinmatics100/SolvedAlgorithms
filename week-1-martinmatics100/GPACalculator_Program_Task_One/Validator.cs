using GPA_Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPACalculator_Program_Task_One
{
    internal class Validator
    {
        //attributes or fields
        Course[]_course { get; set; }

        //constructors
        public Validator(Course[] courses)
        {
            this._course = courses;

        }
        //method to check if coursecode exist
        public bool Exist(string courseCode)
            {
                bool exist = false;
                foreach (Course course in this._course)
                {
                    if (course != null && course.courseCode == courseCode)
                    {
                        exist = true;
                        break;
                    }
                }
                return exist;
            }

            // check if course pattern is followed
            public bool Match(string courseCode)
            {
                Regex coursePattern = new Regex(@"^[A-z]{3}\d{3}$");
                if (!coursePattern.IsMatch(courseCode))
                {
                    return false;
                }
                return true;
            }

        public bool Length(string courseCode)
        {
            if (courseCode.Length != 0)
            {
                return false;
            }
            return true;
        }
        public bool IsLength(string num)
        {
            long length;
            if (!long.TryParse(num, out length) || length < 0 || length < 5)
            {
                return false;
            }
            return true;
        }
     }
 }
