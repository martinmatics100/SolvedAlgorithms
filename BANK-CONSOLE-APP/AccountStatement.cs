using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class AccountStatement : Registration
    {
        public void PrintStatement()
        {
            string accountNumber;
            Customer customer = null!;
            bool isValidAccountNumber = false;

            while (!isValidAccountNumber)
            {
                Console.Write("Enter account number: ");
                accountNumber = Console.ReadLine()!;

                // Validate the entered account number
                customer = ValidateAccountNumber(accountNumber!);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number. Please try again.");
                }
                else
                {
                    isValidAccountNumber = true;
                }
            }

            // Print the account statement for the validated account number
            PrintAccountStatement(customer!);
        }

        private void PrintAccountStatement(Customer customer)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"|-------------------------------------------------------------------------------------------|");
            Console.WriteLine($"|                     ACCOUNT DETAILS FOR ACCOUNT NO {customer.AccountNumber}                             |");
            Console.WriteLine($"|-------------------------------------------------------------------------------------------|");
            Console.WriteLine($"|        DATE            |      DESCRIPTION           |     AMOUNT      |     BALANCE       |");
            Console.WriteLine($"|------------------------|----------------------------|-----------------|-------------------|");

            
            foreach (Transaction transaction in customer.Transactions)
            {
                Console.WriteLine($"| {transaction.Date,-22} | {transaction.Description,-26} | {transaction.Amount,-15} | {transaction.Balance.ToString("C", new CultureInfo("ha-latn-NG")),-17} |");
            }

            Console.WriteLine($"|-------------------------------------------------------------------------------------------|");
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

        private Customer ValidateAccountNumber(string accountNumber)
        {
            // Check if the account number consists only of digits
            if (!int.TryParse(accountNumber, out _))
            {
                return null!; // Return null if the account number contains non-digit characters
            }

            // Search for the customer with the provided account number
            foreach (var item in customers)
            {
                if (item.AccountNumber == accountNumber)
                {
                    return item; // Return the customer if the account number is valid
                }
            }

            return null!; // Return null if the account number is not found
        }

    }
}
