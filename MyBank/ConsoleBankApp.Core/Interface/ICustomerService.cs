using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Core.Interface
{
    public interface ICustomerService
    {
        void RegisterFunction();

        //void PromptForLogin();
        void PromptForLogin();
        void LoginFunction();
    }
}
