//using BANK_CONSOLE_APP.Implementations;
//using BANK_CONSOLE_APP.Models;
using MyBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBankApp.Implementations;
using MyBankApp.Models;

namespace MyBankApp.Interface
{
    public interface IPrinter
    {
        void PrintAccountDetails(Customer customer);
        void PrintAccountStatement(Customer customer);
    }
}
