using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ConsoleBankProgram;
using System.ComponentModel.DataAnnotations;

namespace ConsoleBankProgram

{
    public class Login : Registration
    {
        public Login() : base()
        {
        }
        public Login(string fullName, string passWord, string email, string accountNumber, string accountType, decimal accountBalance) : base(fullName, passWord, email, accountNumber, accountType, accountBalance)
        {
        }

        public void Auntenticator()
        {
            Console.WriteLine();
            Console.WriteLine("|------------|");
            Console.WriteLine("|    LOGIN   |");
            Console.WriteLine("|------------|");
            Console.WriteLine();

            bool isLoggedIn = false;

            while (!isLoggedIn)
            {

                Console.WriteLine("Choose a login option: ");
                Console.WriteLine("1. Email");
                Console.WriteLine();
                Console.WriteLine("2. Account Number");
                Console.WriteLine();
                Console.WriteLine("Enter your choice (1 or 2): ");
                string choice = Console.ReadLine()!;

                if (choice == "1")
                {
                    Console.Write("Enter your email address: ");
                    string inputEmail = Console.ReadLine()!;

                    if (inputEmail == email)
                    {
                        Console.Write("Enter your password: ");
                        string inputPassword = Console.ReadLine()!;

                        if (inputPassword == GetPassword())
                        {
                            Console.Clear();
                            Console.WriteLine("Login successful!");
                            Console.WriteLine();
                            Console.WriteLine("======================================");
                            Console.WriteLine("Welcome, " + fullName + "!");
                            Console.WriteLine("======================================");

                            BankMenu.DisplayBankMenu();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Login failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid email address. Login failed.");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter your account number: ");
                    string inputAccountNumber = Console.ReadLine();

                    if (inputAccountNumber == accountNumber)
                    {
                        Console.Write("Enter your password: ");
                        string inputPassword = Console.ReadLine()!;

                        if (inputPassword == GetPassword())
                        {
                            Console.Clear();
                            Console.WriteLine("Login successful!");
                            Console.WriteLine();
                            Console.WriteLine("======================================");
                            Console.WriteLine("Welcome, " + fullName + "!");
                            Console.WriteLine("======================================");

                            BankMenu.DisplayBankMenu();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Login failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid account number. Login failed.");
                    }
                }
                else
                {
                    Console.WriteLine("invalid choice. login failed. ");
                }

                if (!isLoggedIn)
                {
                    Console.WriteLine("Do you want to try again? (Y/N)");
                    string tryAgain = Console.ReadLine();

                    if (tryAgain.ToUpper() != "Y")
                    {
                        Console.WriteLine("Thank you for using our banking program. Goodbye!");
                        break;
                    }
                }
            }
        }
    }
}
