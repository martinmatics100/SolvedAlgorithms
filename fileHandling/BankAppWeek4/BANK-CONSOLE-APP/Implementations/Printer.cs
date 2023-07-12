using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Interface;
using BANK_CONSOLE_APP.Models;

namespace BANK_CONSOLE_APP.Implementations
{
    public class Printer : IPrinter
    {
        private IValidation _validate;
        public Printer(IValidation validation)
        {
            _validate = validation;
        }
        public void PrintAccountDetails(Customer customer)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("|-----------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                    ACCOUNT DETAILS                                      |");
            Console.WriteLine("|-----------------------------------------------------------------------------------------|");
            Console.WriteLine("|        Full Name     |        Account Number     |       Type      |        Balance     |");
            Console.WriteLine("|-----------------------------------------------------------------------------------------|");

     
                Console.WriteLine("| {0,-20} | {1,-25} | {2,-13} | {3,-18} |", $"{customer.FirstName} {customer.LastName}", customer.AccountNumber, customer.AccountType, customer.Balance.ToString("C", new CultureInfo("ha-Latn-NG")));

            Console.WriteLine("|-----------------------------------------------------------------------------------------|");
            Console.ResetColor();
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine()!;

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine()!;
            }
        }

        public void PrintAccountStatement(Customer customer)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"|-------------------------------------------------------------------------------------------------------|");
            Console.WriteLine($"|                     ACCOUNT DETAILS FOR ACCOUNT NO {customer.AccountNumber}                                         |");
            Console.WriteLine($"|-------------------------------------------------------------------------------------------------------|");
            Console.WriteLine($"|        DATE            |             DESCRIPTION                |     AMOUNT      |     BALANCE       |");
            Console.WriteLine($"|------------------------|----------------------------------------|-----------------|-------------------|");


            foreach (Transaction transaction in customer.Transactions)
            {
                Console.WriteLine($"| {transaction.Date,-22} | {transaction.Description,-38} | {transaction.Amount,-15} | {transaction.Balance.ToString("C", new CultureInfo("ha-latn-NG")),-17} |");
            }

            Console.WriteLine($"|-------------------------------------------------------------------------------------------------------|");
            Console.ResetColor();

            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine()!;

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine()!;
            }

        }
    }
}
