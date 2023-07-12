using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleBankingApp.Validation
{
    internal class ValidatePassword
    {
        public string CollectValidPassword()
        {
            while (true)
            {
                Console.WriteLine("Enter Password (Your password must be a minimum of 6 characters and alphanumeric): ");
                string Password = Console.ReadLine();

                if (Password.Length < 6)
                {
                    Console.WriteLine("Your password must not be less than 6 characters");
                    continue;
                }
                if (!IsAlphanumeric(Password)) 
                {
                    Console.WriteLine("The password must be alphanumeric");
                    continue;
                }
                return Password;
            }
        }

        public bool IsAlphanumeric(string Password)
        {
            return Regex.IsMatch(Password, @"^[a-zA-Z0-9]+$");
        }
    }
}
