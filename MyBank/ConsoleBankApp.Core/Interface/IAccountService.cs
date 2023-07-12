using ConsoleBankApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Core.Interface
{
    public interface IAccountService
    {
        void DepositFunction();
        void WithdrawFunction();
        void TransferFunds();
        bool IsNumeric(string input);
        void PrintAccountDetails();
        Customer ValidateAccountNumber(string accountNumber);
    }
}
