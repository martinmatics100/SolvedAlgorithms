using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp.Validation
{
    internal class ValidateLastName
    {
        public string CollectValidLName()
        {
            while (true)
            {
                Console.Write("Enter LastName (Kindly begin name with uppercase): ");
                string LastName = Console.ReadLine();

                if (!Char.IsUpper(LastName[0]))
                {
                    Console.WriteLine("Your name did not start with upper case, try again");
                    continue;
                }

                if (Char.IsDigit(LastName[0]))
                {
                    Console.WriteLine("Your name must not start with a number");
                    continue;
                }

                return LastName;
            }
        }
    }
}
