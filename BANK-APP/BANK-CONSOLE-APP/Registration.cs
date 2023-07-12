using BANK_CONSOLE_APP.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Accounts;
using BANK_CONSOLE_APP.Validation;

namespace BANK_CONSOLE_APP
{
    internal class Registration
    {
        public static List<Customer> customers = new List<Customer>();

        public void RegisterFunction()
        {

            var ValidateFName = new ValidateFirstName();
            var ValidateLName = new ValidateLastName();
            var ValidateEmail = new ValidateEmail();
            var ValidatePassword = new ValidatePassWord();
            var OpenAccount = new ChooseAccount();
            var balance = new AccountBalance();


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
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Kindly Enter Your Details Below to Register: ");
                Console.WriteLine();


                var FName = ValidateFName.ValidFNameCollector();
                Console.WriteLine();
                var LName = ValidateLName.ValidLNameCollector();
                Console.WriteLine();
                var myEmail = ValidateEmail.ValidEmailCollector();
                Console.WriteLine();
                var myPassword = ValidatePassword.ValidPasswordCollector();
                Console.WriteLine();
                var myAccountNumber = OpenAccount.AccountNumber();
                Console.WriteLine();
                var myAccountType = OpenAccount.AccountType();
                Console.WriteLine(); 
                var myBalance = balance.balanceFunction();


                Customer customer = new Customer(FName, LName, myEmail, myPassword, myAccountNumber, myAccountType, myBalance);
                customers.Add(customer);

                // Console.Clear();
                Console.WriteLine("Customer added successfully");
                Console.WriteLine("Would you want to add another customer? (Y/N)");
                string choice = Console.ReadLine()!;

                if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                    exit = true;
                Console.Clear();



            }

            // Console.Clear();
            Console.WriteLine();
            Console.WriteLine("|--------------------|");
            Console.WriteLine("|    YOUR DETAILS    |");
            Console.WriteLine("|--------------------|");
            Console.WriteLine();

            foreach (var customer in customers)
            {

                Console.WriteLine($"FirstName: {customer.FirstName}");
                Console.WriteLine($"LastName: {customer.LastName}");
                Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
                Console.WriteLine($"AccountType: {customer.AccountType}");
                Console.WriteLine($"Balance: {customer.Balance}");
            }

            // Console.Clear();
            Console.WriteLine("Thanks your for registering. ");
            PromptForLogin();
        }
        private void PromptForLogin()
        {
            Console.WriteLine("Would you like to log in? (Y/N)");
            string loginChoice = Console.ReadLine()!;

            if (loginChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thank you for considering us. You can bank with us next time.");
            }
            else if (loginChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                string loginInput;
                do
                {
                    Console.WriteLine("Please enter  '3' to log in:");
                    loginInput = Console.ReadLine()!;
                } while (loginInput != "3");

                var login = new Login();
                login.LoginFunction();
            }
        }
    }
}
