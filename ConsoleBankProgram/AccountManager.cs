using System;
using System.Collections.Generic;

namespace ConsoleBankProgram
{
    internal class AccountManager : BankMenu
    {
        private static List<String> accounts = new List<String>();
        public static void OpenMultipleAccounts()
        {
            List<string> accountNumbers = new List<string>();

            do
            {
                Console.Write("Which type of account do you want to open \n press 1 for savings account \n press 2 for current account: ");
                string accountType = Console.ReadLine();

                if (accountType.Equals("1", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Creating a savings account...... ");
                    Console.WriteLine();
                    OpenAccountWithInitialDeposit("Savings", accountNumbers);
                }
                else if (accountType.Equals("2", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Creating a current account..... ");
                    OpenAccountWithInitialDeposit("Current", accountNumbers);
                }
                else
                {
                    Console.WriteLine("Invalid account type. Please enter either 'Savings' or 'Current'.");
                    continue;
                }

                Console.Write("Do you want to create another account? Y or N: ");
                string continueOption = Console.ReadLine();

                if (!continueOption.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    BankMenu.DisplayBankMenu();
                }

            } while (true);
        }

        private static void OpenAccountWithInitialDeposit(string accountType, List<string> accountNumbers)
        {
            while (true)
            {
                Console.WriteLine("Enter the initial deposit amount (minimum 2000): ");
                string initialDeposit = Console.ReadLine();
                if (int.TryParse(initialDeposit, out int initialDeposit1))
                {
                    if (initialDeposit1 >= 2000)
                    {
                        string accountNumber = GenerateAccountNumber();
                        accountNumbers.Add(accountNumber);
                        Console.WriteLine("Account opened with initial deposit. Account type: " + accountType + ", Account number: " + accountNumber);
                        break; // Exit the loop after successful deposit amount
                    }
                    else
                    {
                        Console.WriteLine("Invalid deposit amount. Minimum deposit is 2000.");
                    }
                }
                else 
                {
                    Console.WriteLine("Invalid deposit amount. Please enter a valid number.");
                }
            }
        }
        private static string GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(1000000000, 2000000000).ToString();
        }
    }
}