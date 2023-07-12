using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp.AccountType
{
    internal class Account
    {
        public string choice;
        public string Acctype;
        public int AccountNo()
        {
            Console.WriteLine("Enter 1 to create a savings account or 2 to create a current account");
            choice = Console.ReadLine();

            Random random = new Random();
            int accountNumber;

            if (choice == "1")
            {
                accountNumber = random.Next(100000000, 199999999);
            }
            else if (choice == "2")
            {
                accountNumber = random.Next(200000000, 299999999);
            }
            else
            {
                throw new ArgumentException("Invalid choice. Please enter either 1 or 2.");
            }

            return accountNumber;
        }

        public string TypeAccount()
        {
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
                throw new ArgumentException("Invalid Choice, Please Enter a valid number");
            }
            
        }
    }
}

