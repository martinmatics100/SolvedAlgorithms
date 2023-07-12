using ConsoleBankApp.Core.Interface;
using ConsoleBankApp.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Core.Implementation
{
    public class AccountService : IAccountService
    {
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<Account> accounts = new List<Account>();
        public static List<Customer> customers = new List<Customer>();
        public readonly ICustomerService _customerService;
        private readonly ICreateAccount _createaccount;
        //private readonly IBankMenu _bankMenu;


        public decimal Amount;
        public string Description;
        public string AccountNumber;
        public string AccountType;
        public decimal AccountBalance;

        public AccountService(ICustomerService customerService)
        {
            _customerService = customerService;
            // _bankMenu = bankMenu;
        }

        public AccountService()
        {
        }

        public void DepositFunction()
        {
            Console.Clear();
            Console.WriteLine("DEPOSIT FUNDS");
            Console.WriteLine();

            // Prompt user to enter the account number
            string accountNumber;
            Customer customer;
            bool isValidAccountNumber = false;

            do
            {
                Console.Write("Enter account number: ");
                accountNumber = (Console.ReadLine());


                // Validate the entered account number
                customer = ValidateAccountNumber(accountNumber);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number. Please try again.");
                }
                else
                {
                    isValidAccountNumber = true;
                }
            } while (!isValidAccountNumber);

            int amount;

            while (true)
            {
                Console.Write("Enter amount to deposit: ");
                string amountInput = Console.ReadLine();

                if (!int.TryParse(amountInput, out amount))
                {
                    Console.WriteLine("Invalid amount. Please enter a valid amount.");
                    continue;
                }

                break;
            }

            customer.AccountBalance += amount;

            Console.WriteLine($"Your new balance is: {customer.AccountBalance}");
            Console.WriteLine();
            Console.WriteLine("SEE YOUR UPDATES BELOW");

            // Display the customer's details
            Console.WriteLine($"FirstName: {customer.FirstName}");
            Console.WriteLine($"LastName: {customer.LastName}");
            Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
            Console.WriteLine($"AccountType: {customer.AccountType}");
            Console.WriteLine($"Balance: {customer.AccountBalance}");

            Console.WriteLine("---------------------------------------------------------------");

            //// Add deposit transaction to the account transaction history
            //customer.Transactions.Add(new Transaction
            //{
            //    Date = DateTime.Now,
            //    Description = "Deposit",
            //    Amount = amount,
            //    Balance = customer.Balance
            //});
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine();

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine();
            }

            //var menu = new BankMenu();
            //menu.BankMenuFunction();
        }


        public void WithdrawFunction()
        {
            Console.Clear();
            Console.WriteLine("WITHDRAW FUNDS");
            Console.WriteLine();

            string accountNumber;
            Customer customer;

            while (true)
            {
                Console.Write("Enter account number: ");
                accountNumber = Console.ReadLine();

                customer = ValidateAccountNumber(accountNumber);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number. Please try again.");
                    continue;
                }
                else
                {
                    break;
                }
            }

            int amount;

            while (true)
            {
                Console.Write("Enter amount to withdraw: ");
                string amountInput = Console.ReadLine();

                if (!int.TryParse(amountInput, out amount))
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                    continue;
                }

                break;
            }

            if (customer.AccountType == "Savings" && (customer.AccountBalance - amount) < 1000)
            {
                Console.WriteLine("Insufficient balance. Minimum balance requirement for a savings account is 1000.");
                Console.ReadLine();
                return;
            }
            if (amount > customer.AccountBalance)
            {
                Console.WriteLine("Insufficient balance.");
                Console.ReadLine();
                return;
            }

            customer.AccountBalance -= amount;

            Console.WriteLine($"Your new balance is: {customer.AccountBalance}");
            Console.WriteLine();
            Console.WriteLine("SEE YOUR UPDATES BELOW");

            Console.WriteLine($"FirstName: {customer.FirstName}");
            Console.WriteLine($"LastName: {customer.LastName}");
            Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
            Console.WriteLine($"AccountType: {customer.AccountType}");
            Console.WriteLine($"Balance: {customer.AccountBalance}");

            Console.WriteLine("---------------------------------------------------------------");

            //// Add withdrawal transaction to the account transaction history
            //customer.Transactions.Add(new Transaction
            //{
            //    Date = DateTime.Now,
            //    Description = "Withdrawal",
            //    Amount = amount,
            //    Balance = customer.Balance
            //});
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine();

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine();
            }

            //var menu = new BankMenu();
            //menu.BankMenuFunction();
        }

        

        public void TransferFunds()
        {
            Console.Clear();
            Console.WriteLine("TRANSFER FUNDS");
            Console.WriteLine();

            // Prompt user to enter the account number for deposit
            string depositAccountNumber;
            Customer depositCustomer = null;

            while (depositCustomer == null)
            {
                Console.Write("Enter account number to deposit from: ");
                depositAccountNumber = Console.ReadLine();

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
            string receiveAccountNumber = null;
            Customer receiveCustomer = null;

            while (receiveCustomer == null)
            {
                Console.Write("Enter account number to receive funds: ");
                receiveAccountNumber = Console.ReadLine();

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
                string amountInput = Console.ReadLine();
                validAmount = int.TryParse(amountInput, out amount);
            } while (!validAmount);

            // Check if the deposit account has sufficient balance
            if (depositCustomer.AccountBalance < amount)
            {
                Console.WriteLine("Insufficient balance in the deposit account.");
                Console.ReadLine(); // Add a pause before returning to the BankMenu
                return;
            }
            else
            {

                // Update the balances of the deposit and receive customers
                depositCustomer.AccountBalance -= amount;
                receiveCustomer.AccountBalance += amount;

                //depositCustomer.Transactions.Add(new Transaction
                //{
                //    Date = DateTime.Now,
                //    Description = $"Transfer to Acc no {receiveAccountNumber}",
                //    Amount = amount,
                //    Balance = depositCustomer.Balance,
                //});

                //receiveCustomer.Transactions.Add(new Transaction
                //{
                //    Date = DateTime.Now,
                //    Description = $"Transfer from Account {depositCustomer.AccountNumber}",
                //    Amount = amount,
                //    Balance = receiveCustomer.Balance,
                //});
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
            Console.WriteLine($"Balance: {depositCustomer.AccountBalance}");
            Console.WriteLine();
            Console.WriteLine("RECEIVE ACCOUNT DETAILS");
            Console.WriteLine($"AccountNumber: {receiveCustomer.AccountNumber}");
            Console.WriteLine($"FirstName: {receiveCustomer.FirstName}");
            Console.WriteLine($"LastName: {receiveCustomer.LastName}");
            Console.WriteLine($"FullName: {receiveCustomer.FirstName} {receiveCustomer.LastName}");
            Console.WriteLine($"Email: {receiveCustomer.Email}");
            Console.WriteLine($"AccountType: {receiveCustomer.AccountType}");
            Console.WriteLine($"Balance: {receiveCustomer.AccountBalance}");

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine();

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine();
            }

            //var menu = new BankMenu();
            //menu.BankMenuFunction();
        }

        public bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        

        public  void PrintAccountDetails()
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

            foreach (var customer in CustomerService.customers)
            {
                Console.WriteLine("| {0,-20} | {1,-25} | {2,-13} | {3,-18} |", $"{customer.FirstName} {customer.LastName}", customer.AccountNumber, customer.AccountType, customer.AccountBalance.ToString("C", new CultureInfo("ha-Latn-NG")));
            }

            Console.WriteLine("|-----------------------------------------------------------------------------------------|");
            Console.ResetColor();
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine();

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine();
            }

            //var menu = new BankMenu();
            //menu.BankMenuFunction();
        }

        //public void PrintStatement()
        //{
        //    string accountNumber;
        //    Customer customer = null;
        //    bool isValidAccountNumber = false;

        //    while (!isValidAccountNumber)
        //    {
        //        Console.Write("Enter account number: ");
        //        accountNumber = Console.ReadLine();

        //        // Validate the entered account number
        //        customer = ValidateAccountNumber(accountNumber);

        //        if (customer == null)
        //        {
        //            Console.WriteLine("Invalid account number. Please try again.");
        //        }
        //        else
        //        {
        //            isValidAccountNumber = true;
        //        }
        //    }

        //    // Print the account statement for the validated account number
        //    PrintAccountStatement(customer);
        //}

        //private void PrintAccountStatement(Customer customer)
        //{
        //    Console.Clear();
        //    Console.OutputEncoding = Encoding.UTF8;
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine();
        //    Console.WriteLine($"|-------------------------------------------------------------------------------------------|");
        //    Console.WriteLine($"|                     ACCOUNT DETAILS FOR ACCOUNT NO {customer.AccountNumber}                             |");
        //    Console.WriteLine($"|-------------------------------------------------------------------------------------------|");
        //    Console.WriteLine($"|        DATE            |      DESCRIPTION           |     AMOUNT      |     BALANCE       |");
        //    Console.WriteLine($"|------------------------|----------------------------|-----------------|-------------------|");


        //    foreach (Transaction transaction in customer.Transactions)
        //    {
        //        Console.WriteLine($"| {transaction.Date,-22} | {transaction.Description,-26} | {transaction.Amount,-15} | {transaction.AccountBalance.ToString("C", new CultureInfo("ha-latn-NG")),-17} |");
        //    }

        //    Console.WriteLine($"|-------------------------------------------------------------------------------------------|");
        //    Console.ResetColor();

        //    Console.WriteLine("Enter 1 to go back to BankMenu");
        //    string choice = Console.ReadLine();

        //    while (choice != "1")
        //    {
        //        Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
        //        choice = Console.ReadLine();
        //    }

        //    var menu = new BankMenu();
        //    menu.BankMenuFunction();

        //}

        public Customer ValidateAccountNumber(string accountNumber)
        {
            // Check if the account number consists only of digits
            if (!int.TryParse(accountNumber, out _))
            {
                return null; // Return null if the account number contains non-digit characters
            }

            // Search for the customer with the provided account number
            foreach (var item in customers)
            {
                if (item.AccountNumber == accountNumber)
                {
                    return item; // Return the customer if the account number is valid
                }
            }

            return null; // Return null if the account number is not found
        }
    }
}
