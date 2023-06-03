using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class Customer
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public string AccountNumber;
        public string AccountType;
        public decimal Balance;

        public List<Transaction> Transactions { get; set; }

        public Customer(string  FirstName, string LastName, string Email, string Password, string AccountNumber, string AccountType, decimal Balance)
        {
            this.FirstName = FirstName;
            this.LastName = LastName; 
            this.Email = Email;
            this.Password = Password;
            this.AccountNumber = AccountNumber;
            this.AccountType = AccountType;
            this.Balance = Balance;
            this.Transactions = new List<Transaction>();
        }
    }
}
