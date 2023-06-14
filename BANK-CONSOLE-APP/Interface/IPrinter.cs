using BANK_CONSOLE_APP.Implementations;
using BANK_CONSOLE_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP.Interface
{
    public interface IPrinter
    {
        void PrintAccountDetails(Customer customer);
        void PrintAccountStatement(Customer customer);
    }
}
