using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class Logout
    {
        public void LogoutFunction()
        {
            Console.WriteLine("Logged out successfully.");
            Console.WriteLine("Press any key to exit the console...");
            Console.ReadKey();
            //Environment.Exit(0);
        }
    }
}
