using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Core.Interface
{
    public interface ICreateAccount
    {
        string AccountNumber();
        string AccountType();
        decimal AccountBal();
    }
}
