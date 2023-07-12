using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConsoleBankApp.Core;
using ConsoleBankApp.Core.Interface;

namespace ConsoleBankApp
{
    public class UserService
    {

        public readonly ICustomerService _customerService;

        public UserService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public void Run()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                         WELCOME                            ");
            Console.WriteLine();
            Console.WriteLine("Introducing \"SWIFTBANK\" - your gateway to seamless banking. " +
                "\n Join us now and experience financial convenience like never before!");
            Console.ResetColor();
            //Console.WriteLine();
            //Console.WriteLine();


            Console.WriteLine();
            string choice;
            do
            {
                Console.Write($"Press 1 to Register and create account: >> ");
                //Console.WriteLine("Enter your choice");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    _customerService.RegisterFunction();
                    
                }
            } while (choice != "1");
        }
    }
}
