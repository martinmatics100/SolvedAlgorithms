using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace My_Console_Bank_App
{
    internal class Login : Registration
    {
        public Login() : base()
        {
        }
        public Login(string fullName, string passWord, string email, long accountNumber) : base(fullName, passWord, email, accountNumber)
        {
        }
        
        public void Auntenticator()
        {
            Console.WriteLine("===LOGIN===");
            Console.WriteLine("Choose a login option: ");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. Account Number");
            Console.WriteLine("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine()!;

            if (choice == "1")
            {
                Console.WriteLine("Enter your email address: ");
                string inputEmail = Console.ReadLine()!;

                if (inputEmail == email)
                {
                    Console.Write("Enter your password: ");
                    string inputPassword = Console.ReadLine()!;

                    if (inputPassword == GetPassword())
                    {
                        Console.WriteLine("Login successful!");
                        Console.WriteLine("Welcome, " + fullName + "!");
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
                Console.WriteLine("Enter your account number: ");
                int inputAccountNumber = Convert.ToInt32(Console.ReadLine());

                if (inputAccountNumber == accountNumber)
                {
                    Console.Write("Enter your password: ");
                    string inputPassword = Console.ReadLine()!;

                    if (inputPassword == GetPassword())
                    {
                        Console.WriteLine("Login successful!");
                        Console.WriteLine("Welcome, " + fullName + "!");
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
               Console.WriteLine("============================");

        }
        }
    }
