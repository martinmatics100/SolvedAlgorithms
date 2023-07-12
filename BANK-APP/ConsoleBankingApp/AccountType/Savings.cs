using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp.AccountType
{
    internal class Savings
    {
        public int SavingsNo() 
        { 
            Random random = new Random();
            int SavingsAccNo = random.Next(100000000, 199999999);
            return SavingsAccNo;
        }
    }
}
