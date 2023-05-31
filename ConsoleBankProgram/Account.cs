using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankProgram
{
    public class Account
    {
        public string Fullname { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; } 

        public Account(string fullname, string accountnumber, string accountType, decimal balance)
        {
            this.Fullname = fullname;
            this.AccountNumber = accountnumber;
            this.Balance = balance;
            this.AccountType = accountType;

        }
    }
}
