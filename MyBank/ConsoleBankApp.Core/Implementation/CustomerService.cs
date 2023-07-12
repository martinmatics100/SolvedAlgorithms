using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBankApp.Core.Interface;
using ConsoleBankApp.Data;

namespace ConsoleBankApp.Core.Implementation
{
    public class CustomerService : ICustomerService
    {
        public static List<Customer> customers = new List<Customer>();
        private readonly IValidateService _validateService;
        private readonly ICreateAccount _createAccount;
        //private readonly IBankMenu _bankMenu;


        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public string AccountNumber;
        public string AccountType;
        public decimal AccountBalance;

        public CustomerService(IValidateService validateService, ICreateAccount createAccount/*, IBankMenu bankMenu*/)
        {
            _validateService = validateService;
            _createAccount = createAccount;
            //_bankMenu = bankMenu;
        }

        public void RegisterFunction()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Kindly Enter Your Details Below to Register: ");
                Console.WriteLine();

                FirstName = _validateService.ValidFNameCollector();
                LastName = _validateService.ValidLNameCollector();
                Email = _validateService.ValidEmailCollector();
                Password = _validateService.ValidPasswordCollector();
                AccountNumber = _createAccount.AccountNumber();
                AccountType = _createAccount.AccountType();
                AccountBalance = _createAccount.AccountBal();



                Customer customer = new Customer(FirstName, LastName, Email, Password, AccountNumber, AccountType, AccountBalance);
                customers.Add(customer);

                Console.WriteLine("Customer added successfully");
                Console.WriteLine("Would you want to add another customer? (Y/N)");
                string choice = Console.ReadLine();

                while (!choice.Equals("Y", StringComparison.OrdinalIgnoreCase) && !choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid entry. Please enter 'Y' to add another customer or 'N' to implement the login.");
                    choice = Console.ReadLine();
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
                Console.WriteLine($"Balance: {customer.AccountBalance}");
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine("Thank you for registering.");
            PromptForLogin();
        }

        public void PromptForLogin()
        {
            Console.WriteLine("Would you like to log in? (Y/N)");
            string loginChoice = Console.ReadLine();

            if (loginChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thank you for considering us. You can bank with us next time.");
            }
            else if (loginChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                string loginInput;
                do
                {
                    Console.WriteLine("Please enter '3' to log in:");
                    loginInput = Console.ReadLine();
                } while (loginInput != "3");
                LoginFunction();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'Y' to add another customer or 'N' to implement the login.");
                Console.ReadLine();
                PromptForLogin();
            }
        }

        public void LoginFunction()
        {
            Console.WriteLine();
            Console.WriteLine("|------------|");
            Console.WriteLine("|    LOGIN   |");
            Console.WriteLine("|------------|");
            Console.WriteLine();

            Console.Write("Enter your email address: ");
            string loginEmail = Console.ReadLine();

            foreach (var item in customers)
            {
                if (loginEmail == item.Email)
                {
                    Console.Write("Enter your password: ");
                    string loginPassWord = Console.ReadLine();
                    if (loginPassWord == item.Password)
                    {
                        Console.Clear();
                        ShowBankMenu();
                        //var bank = new BankMenu(_);
                        //_bankMenu.BankMenuFunction();
                    }
                    else
                    {
                        LoginFunction();
                    }
                }
            }
        }
        public void ShowBankMenu()
        {
            BankMenu bankMenu = new BankMenu(new AccountService(), this);
            bankMenu.BankMenuFunction();
        }
    }
}
