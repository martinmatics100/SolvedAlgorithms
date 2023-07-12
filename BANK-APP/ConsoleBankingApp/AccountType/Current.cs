using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp.AccountType
{
    internal class Current
    {
        public int CurrentNo()
        {
            Random random = new Random();
            int CurrentAccNo = random.Next(200000000, 299999999);
            return CurrentAccNo;
        }
    }
}
