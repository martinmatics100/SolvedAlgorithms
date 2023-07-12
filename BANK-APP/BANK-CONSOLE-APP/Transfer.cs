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
            Console.Write("Enter account number to deposit from: ");
            int depositAccountNumber = Convert.ToInt32(Console.ReadLine());

            // Validate the deposit account number
            Customer depositCustomer = ValidateAccountNumber(depositAccountNumber);

            if (depositCustomer == null)
            {
                Console.WriteLine("Invalid deposit account number. Please try again.");
                Console.ReadLine(); // Add a pause before returning to the BankMenu
                return;
            }

            // Prompt user to enter the account number to receive funds
            Console.Write("Enter account number to receive funds: ");
            int receiveAccountNumber = Convert.ToInt32(Console.ReadLine());

            // Validate the receive account number
            Customer receiveCustomer = ValidateAccountNumber(receiveAccountNumber);

            if (receiveCustomer == null)
            {
                Console.WriteLine("Invalid receive account number. Please try again.");
                Console.ReadLine(); // Add a pause before returning to the BankMenu
                return;
            }

            Console.Write("Enter amount to transfer: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            // Check if the deposit account has sufficient balance
            if (depositCustomer.Balance < amount)
            {
                Console.WriteLine("Insufficient balance in the deposit account.");
                Console.ReadLine(); // Add a pause before returning to the BankMenu
                return;
            }

            // Update the balances of the deposit and receive customers
            depositCustomer.Balance -= amount;
            receiveCustomer.Balance += amount;

            /*depositCustomer.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = $"Transfer to Account {receiveAccountNumber}",
                Amount = amount,
                Balance = depositCustomer.Balance,
            });

            receiveCustomer.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = $"Transfer from Account {receiveCustomer.AccountNumber}",
                Amount = amount,
                Balance = receiveCustomer.Balance,
            });*/

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

            if (choice == "1")
            {
                var menu = new BankMenu();
                menu.BankMenuFunction();
            }
        }

        private Customer ValidateAccountNumber(int accountNumber)
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
