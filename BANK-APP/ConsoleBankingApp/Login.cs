using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp
{
    internal class Login : Register
    {
        public string LoginEmail;
        public string LoginPassword;


        public void LoginFunc()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("ENTER YOUR DETAILS TO LOGIN");
            Console.WriteLine("------------------------------------------------");


            Console.Write("Enter Email Adderss: ");
            string LoginEmail = Console.ReadLine();
            foreach (var item in customers) 
            {
                if (LoginEmail == item.Email)
                {
                    Console.WriteLine("Enter Password");
                    LoginPassword = Console.ReadLine();
                    if (LoginPassword == item.Password)
                    {
                        Console.Clear();
                        var BankMenu = new BankMenu();
                        BankMenu.BankMenuFunc();
                    }
                    else
                    {
                        LoginFunc();
                    }
                }
                else
                {
                    LoginFunc();
                }
            }


        }
    }
}
