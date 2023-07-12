using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleBankingApp.Validation
{
    internal class ValidateEmail
    {
        public string CollectValidEmail()
        {
            while (true)
            {
                Console.Write("Enter Email Address: ");
                string email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid Email, please enetr a valid email address");
                    continue;
                }
                return email;
            }
        }
        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
