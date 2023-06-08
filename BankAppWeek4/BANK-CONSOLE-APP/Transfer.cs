using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class Transfer : Registration
    {
        public void TransferFunds()
        {
            Console.Clear();
            Console.WriteLine("TRANSFER FUNDS");
            Console.WriteLine();

            // Prompt user to enter the account number for deposit
            string depositAccountNumber;
            Customer depositCustomer = null!;

            while (depositCustomer == null)
            {
                Console.Write("Enter account number to deposit from: ");
                depositAccountNumber = Console.ReadLine()!;

                if (!IsNumeric(depositAccountNumber))
                {
                    Console.WriteLine("Invalid account number format. Please enter a numeric value.");
                    continue;
                }

                depositCustomer = ValidateAccountNumber(depositAccountNumber);

                if (depositCustomer == null)
                {
                    Console.WriteLine("Invalid deposit account number. Please try again.");
                }
            }

            // Prompt user to enter the account number to receive funds
            string receiveAccountNumber = null!;
            Customer receiveCustomer = null!;

            while (receiveCustomer == null)
            {
                Console.Write("Enter account number to receive funds: ");
                receiveAccountNumber = Console.ReadLine()!;

                if (!IsNumeric(receiveAccountNumber))
                {
                    Console.WriteLine("Invalid account number format. Please enter a numeric value.");
                    continue;
                }

                receiveCustomer = ValidateAccountNumber(receiveAccountNumber);

                if (receiveCustomer == null)
                {
                    Console.WriteLine("Invalid receive account number. Please try again.");
                }
            }

            int amount;
            bool validAmount;
            do
            {
                Console.Write("Enter amount to transfer: ");
                string amountInput = Console.ReadLine()!;
                validAmount = int.TryParse(amountInput, out amount);
            } while (!validAmount);

            // Check if the deposit account has sufficient balance
            if (depositCustomer.Balance < amount)
            {
                Console.WriteLine("Insufficient balance in the deposit account.");
                Console.ReadLine(); // Add a pause before returning to the BankMenu
                return;
            }
            else
            {

                // Update the balances of the deposit and receive customers
                depositCustomer.Balance -= amount;
                receiveCustomer.Balance += amount;

                depositCustomer.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Description = $"Transfer to Acc no {receiveAccountNumber}",
                    Amount = amount,
                    Balance = depositCustomer.Balance,
                });

                receiveCustomer.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Description = $"Transfer from Account {depositCustomer.AccountNumber}",
                    Amount = amount,
                    Balance = receiveCustomer.Balance,
                });
            }

            Console.WriteLine("Transfer successful.");
            Console.WriteLine();
            Console.WriteLine("DEPOSIT ACCOUNT DETAILS");
            Console.WriteLine($"AccountNumber: {depositCustomer.AccountNumber}");
            Console.WriteLine($"FirstName: {depositCustomer.FirstName}");
            Console.WriteLine($"LastName: {depositCustomer.LastName}");
            Console.WriteLine($"FullName: {depositCustomer.FirstName} {depositCustomer.LastName}");
            Console.WriteLine($"Email: {depositCustomer.Email}");
            Console.WriteLine($"AccountType: {depositCustomer.AccountType}");
            Console.WriteLine($"Balance: {depositCustomer.Balance}");
            Console.WriteLine();
            Console.WriteLine("RECEIVE ACCOUNT DETAILS");
            Console.WriteLine($"AccountNumber: {receiveCustomer.AccountNumber}");
            Console.WriteLine($"FirstName: {receiveCustomer.FirstName}");
            Console.WriteLine($"LastName: {receiveCustomer.LastName}");
            Console.WriteLine($"FullName: {receiveCustomer.FirstName} {receiveCustomer.LastName}");
            Console.WriteLine($"Email: {receiveCustomer.Email}");
            Console.WriteLine($"AccountType: {receiveCustomer.AccountType}");
            Console.WriteLine($"Balance: {receiveCustomer.Balance}");

            Console.WriteLine("---------------------------------------------------------------");
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

        private bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        private Customer ValidateAccountNumber(string accountNumber)
        {
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
