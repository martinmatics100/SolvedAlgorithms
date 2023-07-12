using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MyBankApp.Implementations;
using MyBankApp.Models;
//using BANK_CONSOLE_APP.Implementations;
//using BANK_CONSOLE_APP.Models;

namespace MyBankApp.Interface
{
    public interface IValidation
    {
        string ValidEmailCollector();

        string ValidNameCollector(string prompt);

        string ValidPasswordCollector();

        bool IsValidPassword(string password);
        bool IsNumeric(string input);

    }
}
