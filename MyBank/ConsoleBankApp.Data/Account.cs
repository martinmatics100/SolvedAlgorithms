using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Data
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountType { get; set; }

        public Account(string AccountNumber, string AccountType, decimal AccountBalance)
        {
            this.AccountNumber = AccountNumber;
            this.AccountBalance = AccountBalance;
            this.AccountType = AccountType;
        }
    }
}
