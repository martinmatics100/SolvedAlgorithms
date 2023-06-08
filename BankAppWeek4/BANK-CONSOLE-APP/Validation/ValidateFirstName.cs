using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP.Validation
{
    public class ValidateFirstName
    {
        public string ValidFNameCollector()
        {
            while (true)
            {
                Console.Write("Enter Your FirstName (Kindly begin name with uppercase): ");
                string FirstName = Console.ReadLine()!;

                if (!Char.IsUpper(FirstName[0]))
                {
                    Console.WriteLine("Your name did not start with upper case, try again");
                    Console.Beep();
                    continue;
                }

                if (Char.IsDigit(FirstName[0]))
                {
                    Console.WriteLine("Your name must not start with a digit");
                    Console.Beep();
                    continue;
                }
                return FirstName;
            }
        }
    }
}
