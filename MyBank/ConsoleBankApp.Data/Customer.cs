using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Data
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }



        public Customer(string FirstName, string LastName, string Email, string Password, string accountNumber, string accountType, decimal accountBalance)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.AccountNumber = accountNumber;
            this.AccountType = accountType;
            this.AccountBalance = accountBalance;
        }
    }
}
