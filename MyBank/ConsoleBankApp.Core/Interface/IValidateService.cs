using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleBankApp.Core.Interface
{
    public interface IValidateService
    {
        string ValidEmailCollector();

        string ValidFNameCollector();

        string ValidLNameCollector();

        string ValidPasswordCollector();

        bool IsValidPassword(string password);

        bool IsValidEmail(string email);
       
    }
}
