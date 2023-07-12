using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BANK_CONSOLE_APP.Interface;
using BANK_CONSOLE_APP.Models;

namespace BANK_CONSOLE_APP.Implementations
{
    public class Registration : IRegistration
    {
        public List<Customer> customers;// = new List<Customer>();
        private IValidation _validate;
        private IPrinter _printer;
        private IPrinter printer;
        private IValidation validation;

        //private string FilePath; // path to the file

        public Registration(IValidation validation, IPrinter printer)
        {
            customers = new List<Customer>();
            _validate = validation;
            _printer = printer;
        }

        public Registration(string filePath, IPrinter printer, IValidation validation)
        {
            this.printer = printer;
            this.validation = validation;
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }


        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public void RegisterFunction()
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                         WELCOME                            ");
                Console.WriteLine();
                Console.WriteLine("Introducing \"SWIFTBANK\" - your gateway to seamless banking. " +
                    "\n Join us now and experience financial convenience like never before!");
                Console.WriteLine();
                Console.WriteLine("Kindly Enter Your Details Below to Register And Create An Account: ");
                Console.ResetColor();
                Console.WriteLine();

                var FName = _validate.ValidNameCollector("First Name");
                Console.WriteLine();
                var LName = _validate.ValidNameCollector("Last Name");
                Console.WriteLine();
                var myEmail = _validate.ValidEmailCollector();
                Console.WriteLine();
                var myPassword = _validate.ValidPasswordCollector();
                Console.WriteLine();
                var myAccountNumber = AccountNumber();
                Console.WriteLine();
                var myAccountType = AccountType();
                Console.WriteLine();
                var myBalance = balanceFunction();

                Customer customer = new Customer(FName, LName, myEmail, myPassword, myAccountNumber, myAccountType, myBalance);
                customers.Add(customer);

                Console.WriteLine("Customer added successfully");
                Console.WriteLine("Would you want to add another customer? (Y/N)");
                string choice = Console.ReadLine()!;

                while (!choice.Equals("Y", StringComparison.OrdinalIgnoreCase) && !choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid entry. Please enter 'Y' to add another customer or 'N' to implement the login.");
                    choice = Console.ReadLine()!;
                }

                if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    exit = true;
                }
                Console.Clear();
            }

            Console.WriteLine();
            Console.WriteLine("|--------------------|");
            Console.WriteLine("|    YOUR DETAILS    |");
            Console.WriteLine("|--------------------|");
            Console.WriteLine();

            foreach (var customer in customers)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"FirstName: {customer.FirstName}");
                Console.WriteLine($"LastName: {customer.LastName}");
                Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
                Console.WriteLine($"AccountType: {customer.AccountType}");
                Console.WriteLine($"Balance: {customer.Balance}");
                Console.ResetColor();
                Console.WriteLine();
            }


            Console.WriteLine("Thank you for registering.");
        }

        public string AccountNumber()
        {
            Console.Write("Enter 1 to create a savings account or 2 to create a current account:  ");
            string? choice;

            while (true)
            {
                choice = Console.ReadLine();

                if (choice == "1" || choice == "2")
                    break;
                    Console.Write("Invalid choice. Please enter either 1 for savings account or 2 for current account: ");
            }

            Random random = new Random();
            string accountNumber = random.Next(1000000000, 1999999999).ToString();

            return accountNumber;
        }

        public string AccountType()
        {
            Console.WriteLine("Please enter either 1 for savings account or 2 for current account");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                return "Savings Account";
            }
            else if (choice == "2")
            {
                return "Current Account";
            }
            else
            {
                throw new ArgumentException("Invalid choice. Please enter either 1 for savings account or 2 for current account.");
            }
        }

        public string CurrentNumber()
        {
            Random random = new Random();
            var CurrentAccNo = random.Next(1000000000, 1999999999).ToString();
            return CurrentAccNo;
        }

        public string SavingsNumber()
        {
            Random random = new Random();
            var SavingsAccNo = random.Next(100000000, 199999999).ToString();
            return SavingsAccNo;
        }

        public void LoginFunction()
        {
            Console.WriteLine();
            Console.WriteLine("|------------|");
            Console.WriteLine("|    LOGIN   |");
            Console.WriteLine("|------------|");
            Console.WriteLine();

            Console.Write("Enter your email address: ");
            string loginEmail = Console.ReadLine()!;
            Console.Write("Enter your password: ");
            string loginPassWord = Console.ReadLine()!;

            var customer = GetCustomers().Find(x => x.Email == loginEmail && x.Password == loginPassWord);
            if (customer != null)
            {
                string choice;
                do
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("|-------------------------|");
                    Console.WriteLine("|         BANK MENU       |");
                    Console.WriteLine("|-------------------------|");
                    Console.WriteLine();
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine();
                    Console.WriteLine("1. CREATE MORE ACCOUNT");
                    Console.WriteLine();
                    Console.WriteLine("2. MAKE A DEPOSIT");
                    Console.WriteLine();
                    Console.WriteLine("3. MAKE A WITHDRAWAL");
                    Console.WriteLine();
                    Console.WriteLine("4. MAKE A TRANSFER");
                    Console.WriteLine();
                    Console.WriteLine("5. GET ACCOUNT DETAILS");
                    Console.WriteLine();
                    Console.WriteLine("6. GET STATEMENT OF ACCOUNTS");
                    Console.WriteLine();
                    Console.WriteLine("7. LOGOUT");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.Write("Enter your choice (1-7): ");
                    choice = Console.ReadLine()!;

                    switch (choice)
                    {
                        case "1":
                            Console.Write("YOU SELECTED CREATE MORE ACCOUNT.");
                            RegisterFunction();

                            break;
                        case "2":
                            Console.Write("YOU SELCECTED MAKE A DEPOSIT.");
                            depositFunction();

                            break;
                        case "3":
                            Console.Write("YOU SELECTED MAKE A WITHDRAWAL.");
                            withdrawFunction();

                            break;
                        case "4":
                            Console.Write("YOU SELECTED MAKE A TRANSFER.");
                            TransferFunds();

                            break;
                        case "5":
                            Console.Write("YOU SELECTED GET ACCOUNT DETAILS.");
                            _printer.PrintAccountDetails(customer);
                            break;
                        case "6":
                            Console.Write("YOU SELECTED GET STATEMENT OF ACCOUNT.");
                            _printer.PrintAccountStatement(customer);

                            break;
                        case "7":
                            Console.Write("THANK YOU FOR BANKING WITH US. HAVE A WONDERFUL DAY: ");
                            LogoutFunction();

                            break;
                        default:
                            Console.Write("Invalid choice.");
                            break;
                    }

                } while (choice != "7");

            }
        }

        public void LogoutFunction()
        {
            Console.WriteLine("  Logged out successfully.");
            Console.WriteLine("Press any key to exit the console...");
            Console.ReadKey();
            //Environment.Exit(0);
        }

        public decimal balanceFunction()
        {
            decimal balance = 0;
            return balance;
        }

        public void depositFunction()
        {
            Console.Clear();
            Console.WriteLine("DEPOSIT FUNDS");
            Console.WriteLine();

            // Prompt user to enter the account number
            string accountNumber;
            bool isValidAccountNumber = false;

            do
            {
                Console.Write("Enter account number: ");
                accountNumber = Console.ReadLine()!;


                // Validate the entered account number
                var customer = GetCustomers().Find(x=>x.AccountNumber == accountNumber);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number. Please try again.");
                }
                else
                {
                    int amount;

                    while (true)
                    {
                        Console.Write("Enter amount to deposit: ");
                        string amountInput = Console.ReadLine()!;

                        if (!int.TryParse(amountInput, out amount))
                        {
                            Console.WriteLine("Invalid amount. Please enter a valid amount.");
                            continue;
                        }

                        break;
                    }

                    customer!.Balance += amount;

                    Console.WriteLine($"Your new balance is: {customer.Balance}");
                    Console.WriteLine();
                    Console.WriteLine("SEE YOUR UPDATES BELOW");

                    // Display the customer's details
                    Console.WriteLine($"FirstName: {customer.FirstName}");
                    Console.WriteLine($"LastName: {customer.LastName}");
                    Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
                    Console.WriteLine($"AccountType: {customer.AccountType}");
                    Console.WriteLine($"Balance: {customer.Balance}");

                    Console.WriteLine("---------------------------------------------------------------");

                    // Add deposit transaction to the account transaction history
                    customer.Transactions.Add(new Transaction
                    {
                        Date = DateTime.Now,
                        Description = "Deposit",
                        Amount = amount,
                        Balance = customer.Balance
                    });


                    isValidAccountNumber = true;
                }
            } while (!isValidAccountNumber);

            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine()!;

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine()!;
            }
        }

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

                if (!_validate.IsNumeric(depositAccountNumber))
                {
                    Console.WriteLine("Invalid account number format. Please enter a numeric value.");
                    continue;
                }

                depositCustomer = GetCustomers().Find(x => x.AccountNumber == depositAccountNumber);

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

                if (!_validate.IsNumeric(receiveAccountNumber))
                {
                    Console.WriteLine("Invalid account number format. Please enter a numeric value.");
                    continue;
                }

                receiveCustomer = GetCustomers().Find(x => x.AccountNumber == receiveAccountNumber);

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
        }

        public void withdrawFunction()
        {
            Console.Clear();
            Console.WriteLine("WITHDRAW FUNDS");
            Console.WriteLine();

            string accountNumber;
            Customer customer;

            while (true)
            {
                Console.Write("Enter account number: ");
                accountNumber = Console.ReadLine()!;

                customer = GetCustomers().Find(x => x.AccountNumber == accountNumber);

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
                string amountInput = Console.ReadLine()!;

                if (!int.TryParse(amountInput, out amount))
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                    continue;
                }

                break;
            }

            if (customer.AccountType == "Savings" && customer.Balance - amount < 1000)
            {
                Console.WriteLine("Insufficient balance. Minimum balance requirement for a savings account is 1000.");
                Console.ReadLine();
                return;
            }
            if (amount > customer.Balance)
            {
                Console.WriteLine("Insufficient balance.");
                Console.ReadLine();
                return;
            }

            customer.Balance -= amount;

            Console.WriteLine($"Your new balance is: {customer.Balance}");
            Console.WriteLine();
            Console.WriteLine("SEE YOUR UPDATES BELOW");

            Console.WriteLine($"FirstName: {customer.FirstName}");
            Console.WriteLine($"LastName: {customer.LastName}");
            Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
            Console.WriteLine($"AccountType: {customer.AccountType}");
            Console.WriteLine($"Balance: {customer.Balance}");

            Console.WriteLine("---------------------------------------------------------------");

            // Add withdrawal transaction to the account transaction history
            customer.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Withdrawal",
                Amount = amount,
                Balance = customer.Balance
            });
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine()!;

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine()!;
            }
        }

        public void BankMenuFunction(Registration registered, Customer customer)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|         BANK MENU       |");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine();
            Console.WriteLine("1. CREATE MORE ACCOUNT");
            Console.WriteLine();
            Console.WriteLine("2. MAKE A DEPOSIT");
            Console.WriteLine();
            Console.WriteLine("3. MAKE A WITHDRAWAL");
            Console.WriteLine();
            Console.WriteLine("4. MAKE A TRANSFER");
            Console.WriteLine();
            Console.WriteLine("5. GET ACCOUNT DETAILS");
            Console.WriteLine();
            Console.WriteLine("6. GET STATEMENT OF ACCOUNTS");
            Console.WriteLine();
            Console.WriteLine("7. LOGOUT");
            Console.WriteLine();
            Console.ResetColor();
            Console.Write("Enter your choice (1-7): ");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    Console.Write("YOU SELECTED CREATE MORE ACCOUNT.");
                    RegisterFunction();

                    break;
                case "2":
                    Console.Write("YOU SELCECTED MAKE A DEPOSIT.");
                    depositFunction();

                    break;
                case "3":
                    Console.Write("YOU SELECTED MAKE A WITHDRAWAL.");
                    withdrawFunction();

                    break;
                case "4":
                    Console.Write("YOU SELECTED MAKE A TRANSFER.");
                    TransferFunds();

                    break;
                case "5":
                    Console.Write("YOU SELECTED GET ACCOUNT DETAILS.");
                    _printer.PrintAccountDetails(customer);
                    break;
                case "6":
                    Console.Write("YOU SELECTED GET STATEMENT OF ACCOUNT.");
                    _printer.PrintAccountStatement(customer);

                    break;
                case "7":
                    Console.Write("THANK YOU FOR BANKING WITH US. HAVE A WONDERFUL DAY: ");
                    LogoutFunction();

                    break;
                default:
                    Console.Write("Invalid choice.");
                    break;
            }
        }

        public void Instruction()
        {

            string choice;

                do
                {
                    Console.WriteLine("|--------------------------------------------|");
                    Console.WriteLine("|    YOU'RE WELCOME TO ESKIMO CONSOLE BANK   |");
                    Console.WriteLine("|--------------------------------------------|");
                    Console.WriteLine();
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");

                    choice = Console.ReadLine()!;

                    switch (choice)
                    {
                        case "1":
                            RegisterFunction();

                            break;
                        case "2":
                            LoginFunction();

                            break;
                        case "3":

                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                }while (choice != "3");


            Console.WriteLine("Thank you for using ESKIMO Console Bank App. Goodbye!");
        }
    }
}
