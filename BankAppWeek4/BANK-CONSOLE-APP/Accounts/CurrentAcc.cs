using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP.Accounts
{
    public class CurrentAcc
    {
        public string CurrentNumber()
        {
            Random random = new Random();
            var CurrentAccNo = random.Next(1000000000, 1999999999).ToString();
            return CurrentAccNo;
        }
    }
}
