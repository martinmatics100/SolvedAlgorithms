using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BANK_CONSOLE_APP.Implementations;
using BANK_CONSOLE_APP.Models;

namespace BANK_CONSOLE_APP.Interface
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
