using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class AccountDetailsTable
    {
        public static void PrintAccountDetails()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("|-----------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                    ACCOUNT DETAILS                                      |");
            Console.WriteLine("|-----------------------------------------------------------------------------------------|");
            Console.WriteLine("|        Full Name     |        Account Number     |       Type      |        Balance     |");
            Console.WriteLine("|-----------------------------------------------------------------------------------------|");

            foreach (var customer in Registration.customers)
            {
                Console.WriteLine("| {0,-20} | {1,-25} | {2,-13} | {3,-18} |", $"{customer.FirstName} {customer.LastName}", customer.AccountNumber, customer.AccountType, customer.Balance.ToString("C", new CultureInfo("ha-Latn-NG")));
            }

            Console.WriteLine("|-----------------------------------------------------------------------------------------|");
            Console.ResetColor();  
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine()!;

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine()!;
            }

            var menu = new BankMenu();
            menu.BankMenuFunction();
        }
    }
}
