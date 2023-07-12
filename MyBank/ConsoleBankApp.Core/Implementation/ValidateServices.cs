using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleBankApp.Core.Interface;
using ConsoleBankApp;

namespace ConsoleBankApp.Core.Implementation
{
    public class ValidateServices : IValidateService
    {
        public string ValidEmailCollector()
        {
            while (true)
            {
                Console.Write("Enter Email Address: ");
                string email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid Email, please enter  a valid email address");
                    Console.Beep();
                    continue;
                }
                return email;
            }
        }

        public string ValidFNameCollector()
        {
            while (true)
            {
                Console.Write("Enter Your FirstName (Kindly begin name with uppercase): ");
                string FirstName = Console.ReadLine();

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

        public string ValidLNameCollector()
        {
            while (true)
            {
                Console.Write("Enter Your LastName (Kindly begin name with uppercase): ");
                string LastName = Console.ReadLine();

                if (!Char.IsUpper(LastName[0]))
                {
                    Console.WriteLine("Your name did not start with upper case, try again");
                    Console.Beep();
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

        public string ValidPasswordCollector()
        {
            while (true)
            {
                Console.Write("Enter a Password " +
                "\n (Password requirements: " +
                "\n 1. Minimum 6 characters, " +
                "\n 2. alphanumeric, " +
                "\n 3. and at least one special character (@, #, $, %, ^, &, !).)): ");
                string password = Console.ReadLine();

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

        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(gmail\.com|yahoo\.com|outlook\.com)$");
        }
    }
}
