using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class Instruction
    {
        public void Instruction1()
        {
            Console.WriteLine("|--------------------------------------------|");
            Console.WriteLine("|    YOU'RE WELCOME TO ESKIMO CONSOLE BANK   |");
            Console.WriteLine("|--------------------------------------------|");
            Console.WriteLine();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        var registration = new Registration();
                        registration.RegisterFunction();

                        break;
                    case "2":
                        var login = new Login();
                        login.LoginFunction();

                        break;
                    case "3":

                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Thank you for using ESKIMO Console Bank App. Goodbye!");
        }
    }
}
