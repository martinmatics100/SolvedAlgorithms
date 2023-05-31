using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Console_Bank_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            login.Register(); // for registration
            Console.WriteLine();
            login.Auntenticator(); // for login
        }
    }
}

