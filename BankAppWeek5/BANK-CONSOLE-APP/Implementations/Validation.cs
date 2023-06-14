using BANK_CONSOLE_APP.Interface;
using BANK_CONSOLE_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace BANK_CONSOLE_APP.Implementations
{
    public class Validation : IValidation
    {
        public string ValidEmailCollector()
        {
            while (true)
            {
                Console.Write("Enter Email Address: ");
                string email = Console.ReadLine()!;

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid Email, please enter  a valid email address");
                    Console.Beep();
                    continue;
                }
                return email;
            }
        }
        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(gmail\.com|yahoo\.com|outlook\.com)$");
        }

        public string ValidNameCollector(string prompt)
        {
            while (true)
            {
                Console.Write($"Enter Your {prompt} (Kindly begin name with uppercase): ");
                string Name = Console.ReadLine()!;

                if (!char.IsUpper(Name[0]) || char.IsDigit(Name[0]))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid entry. Name must cannot begin with Lower case or digits");
                    
                    //Console.Beep();
                    continue;
                }
                return Name;
            }
        }

        public string ValidPasswordCollector()
        {
            while (true)
            {
                Console.Write("Enter a Password " +
                "\n (Password requirements: " +
                "\n 1. Minimum 6 characters, " +
                "\n 2. alphanumeric, " +
                "\n 3. and at least one special character (@, #, $, %, ^, &, !).)): ");
                string password = Console.ReadLine()!;

                if (!IsValidPassword(password))
                {
                    Console.WriteLine("Invalid password: ");
                    continue;
                }
                return password;
            }
        }

        public bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[@#$%^&!])(?=.*[a-zA-Z0-9]).{6,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        public bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }
    }
}
