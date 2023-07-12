using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp.Validation
{
    internal class ValidateFirstName
    {
        public string CollectValidFName() 
        { 
            while (true)
            {
                Console.Write("FirstName (Kindly begin name with capital letter): ");
                string FirstName = Console.ReadLine();

                if (!Char.IsUpper(FirstName[0]))
                {
                    Console.WriteLine("Your name did not start with upper case, try again");
                    continue;
                }

                if (Char.IsDigit(FirstName[0]))
                {
                    Console.WriteLine("Your name must not start with a digit");
                    continue;
                }
                return FirstName;
            }
        }
    }
}
