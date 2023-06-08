using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP.Validation
{
    public class ValidatePassWord
    {
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
        //public string ValidPasswordCollector()
        //{
        //    string passwordPattern = @"^(?=.*[@#$%^&!])(?=.*[a-zA-Z0-9]).{6,}$";

        //    Console.Write("Enter a Password " +
        //        "\n (Password requirements: " +
        //        "\n 1. Minimum 6 characters, " +
        //        "\n 2. alphanumeric, " +
        //        "\n 3. and at least one special character (@, #, $, %, ^, &, !).)): ");
        //    string password = Console.ReadLine()!;

        //    while (!Regex.IsMatch(password, passwordPattern))
        //    {
        //        Console.WriteLine("Invalid password! Please try again.");
        //        Console.Write("Enter a Password " +
        //        "\n (Password requirements: " +
        //        "\n 1. Minimum 6 characters, " +
        //        "\n 2. alphanumeric, " +
        //        "\n 3. and at least one special character (@, #, $, %, ^, &, !).)): ");
        //        password = Console.ReadLine()!;
        //    }

        //    return password;
        //}
    }
}
