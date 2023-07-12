using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP.Accounts
{
    internal class SavingsAcc
    {
        public long SavingsNumber()
        {
            Random random = new Random();
            var SavingsAccNo = random.Next(100000000, 199999999);
            return SavingsAccNo;
        }
    }
}
