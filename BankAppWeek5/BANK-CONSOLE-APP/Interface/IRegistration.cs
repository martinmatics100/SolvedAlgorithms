using BANK_CONSOLE_APP.Implementations;
using BANK_CONSOLE_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP.Interface
{
    public interface IRegistration
    {
        void AddCustomer(Customer customer);
        string AccountNumber();
        string AccountType();
        string CurrentNumber();
        string SavingsNumber();
        void LoginFunction();
        void LogoutFunction();
        decimal balanceFunction();
        void depositFunction();
        void TransferFunds();
        void withdrawFunction();
        void BankMenuFunction(Registration registered, Customer customer);
        void Instruction();
    }
}
