using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class Login : Registration
    {
        string? loginEmail;
        string? loginPassWord; 
          
        public void LoginFunction()
        {
            Console.WriteLine();
            Console.WriteLine("|------------|");
            Console.WriteLine("|    LOGIN   |");
            Console.WriteLine("|------------|");
            Console.WriteLine();

            Console.Write("Enter your email address: ");
            string loginEmail = Console.ReadLine()!;

            foreach(var item in customers)
            {
                if(loginEmail == item.Email)
                {
                    Console.Write("Enter your password: ");
                    string loginPassWord = Console.ReadLine()!;
                    if(loginPassWord == item.Password)
                    {
                        Console.Clear();
                        var bankMenu = new BankMenu();
                        bankMenu.BankMenuFunction();
                    }
                    else
                    {
                        LoginFunction();
                    }
                }
            }
        }
    }
}
