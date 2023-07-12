using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp
{
    internal class Index
    {
        public void RegIndex()
        {
            Console.WriteLine("---WELCOME TO SEAPACK BANK---");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("|SELECT AN OPTION BELOW TO GET STARTED OR CONTINUE       |");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Register: Press 1 to Register;");
            Console.WriteLine();
            Console.WriteLine("Login: Press 2 to login");

            Console.WriteLine();
            Console.WriteLine("Enter your choice");
            var choice = Console.ReadLine();

            if ( choice == "1")
            {
                var Reg = new Register();
                Reg.RegisterFunc();
            }
            if (choice == "2")
            {
                var login = new Login();
                login.LoginFunc();
            }
        }

    }
}
