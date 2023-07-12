using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Data
{
    public class Transaction
    {
        public decimal Amount;
        public string Description;
        public DateTime Date;
        public decimal AccountBalance;
        public Transaction(decimal Amount, string Description, DateTime date, decimal accountBalance)
        {
            this.Amount = Amount;
            this.Description = Description;
            Date = date;
            AccountBalance = accountBalance;
        }
    }
}
