using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBankingApp.Validation;
using ConsoleBankingApp.AccountType;

namespace ConsoleBankingApp
{
    internal class Register
    {
       public static List<Customer> customers = new List<Customer>();
        public void RegisterFunc()
        {
           
            var ValidateFName = new ValidateFirstName();
            var ValidateLName = new ValidateLastName();
            var ValidateEmail = new ValidateEmail();
            var ValidatePassword = new ValidatePassword();
            var OpenAccount = new Account();
            var balance = new Balance();
           

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                
                Console.WriteLine("Enter Your Details Below to Register:");


                var FName = ValidateFName.CollectValidFName();
                string LName =ValidateLName.CollectValidLName();
                string myEmail = ValidateEmail.CollectValidEmail();
                string myPassword = ValidatePassword.CollectValidPassword();
                int myAccountNumber = OpenAccount.AccountNo();
                string myAccountType = OpenAccount.TypeAccount();
                int myBalance = balance.balanceFunc();
                

                Customer customer = new Customer(FName, LName, myEmail, myPassword, myAccountNumber, myAccountType, myBalance);
                customers.Add(customer);

               // Console.Clear();
                Console.WriteLine("Customer added successfully");
                Console.WriteLine("Would you want to add another customer? (Y/N)");
                string choice = Console.ReadLine();

                if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                    exit = true;



            }

           // Console.Clear();
            Console.WriteLine("THE CUSTOMER DETAILS");
            Console.WriteLine("|--------------------------------------|");

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
            Console.WriteLine("Thank your for registering. Now, input 3 to login");
            string LoginInput = Console.ReadLine();

            if (LoginInput == "3")
            {
                var Login = new Login();
                Login.LoginFunc();
            }
        }

        
    }
}
