using ConsoleBankApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Core.Implementation
{
    public class BankMenu : IBankMenu
    {

        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        public BankMenu(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }
        public void BankMenuFunction()
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
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("YOU SELECTED CREATE MORE ACCOUNT.");
                    _customerService.RegisterFunction();
                    break;
                case "2":
                    Console.Write("YOU SELCECTED MAKE A DEPOSIT.");
                    _accountService.DepositFunction();
                    break;
                case "3":
                    Console.Write("YOU SELECTED MAKE A WITHDRAWAL.");
                    _accountService.WithdrawFunction();

                    break;
                case "4":
                    Console.Write("YOU SELECTED MAKE A TRANSFER.");
                    _accountService.TransferFunds();

                    break;
                case "5":
                    Console.Write("YOU SELECTED GET ACCOUNT DETAILS.");
                    _accountService.PrintAccountDetails();
                    break;
                case "6":
                    Console.Write("YOU SELECTED GET STATEMENT OF ACCOUNT.");
                    //var statement = new AccountStatement();
                    //statement.PrintStatement();

                    break;
                case "7":
                    Console.Write("THANK YOU FOR BANKING WITH US. HAVE A WONDERFUL DAY");
                    //var logout = new Logout();
                    //logout.LogoutFunction();

                    break;
                default:
                    Console.Write("Invalid choice.");
                    break;
            }
        }
    }
}
