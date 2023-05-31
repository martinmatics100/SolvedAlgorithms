using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace My_Console_Bank_App
{
    internal class Registration
    {
        //fields or memebers of the Registration Class
        protected string fullName;
        protected string email;
        protected string passWord;
        protected long accountNumber;
       
        public Registration()
        {
            fullName = "";
            email = "";
            passWord = "";
            accountNumber = 0;
        }

        //Constructors of the field or members
        public Registration(string fullname, string email, string passWord, long accountNumber)
        {
            this.fullName = fullname;
            this.email = email;
            this.passWord = passWord;
            this.accountNumber = accountNumber;
            //this.accountType = accountType;
        }

        public void Register()
        {
            Console.WriteLine("|--------------------|");
            Console.WriteLine("|    REGISTRATION    |");
            Console.WriteLine("|--------------------|");
            Console.WriteLine();
            Console.Write("ENTER YOUR FULL NAME: ");
            fullName = Console.ReadLine().ToUpper()!;

            while (!IsValidName(fullName))
            {
                Console.WriteLine("Invalid name format. please enter a valid name");
                Console.Write("ENTER YOUR FULL NAME: ");
                fullName = Console.ReadLine()!;
            }

            Console.Write("ENTER YOUR EMAIL ADDRESS: ");
            email = Console.ReadLine()!;

            while (!IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format. please enter a valid email adderess. ");
                Console.Write("ENTER YOUR EMAIL ADDRESS: ");
                email = Console.ReadLine()!;
            }

            Console.Write("ENTER A PASSWORD: ");
            passWord = Console.ReadLine()!;

            while (!IsValidPassWord(passWord))
            {
                Console.WriteLine("Invalid password format. Please enter a password with at least 6 characters, including alphanumeric and at least one special character.");
                Console.Write("Enter a password: ");
                passWord = Console.ReadLine()!;
            }

            //ChooseAccountType();

            GenerateAccountNumber();

            Console.WriteLine("REGISTRATION SUCCESSFUL! ");
            PrintDetails(); // this displays customers details
            Console.WriteLine("=========================");
        }


        public void GenerateAccountNumber()
        {
            Random random = new Random();
            accountNumber = random.Next(1000000000, 1999999999);
        }

        private bool IsValidEmail(string email1)
        {
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        //checking if the name begins with upper case
        private bool IsValidName(string name)
        {
            
            return !Regex.IsMatch(name, @"^\d") && Regex.IsMatch(name, @"^[A-Za-z][A-Za-z\s]*$");

        }

        private bool IsValidPassWord(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Za-z0-9])(?=.*[@#$%^&!]).{6,}$");
        }
        private void PrintDetails()
        {
            Console.WriteLine("Your details: ");
            Console.WriteLine("Full Name: " + fullName);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Account Number: " + accountNumber);
            //Console.WriteLine("Account type: " + accountType);
            Console.WriteLine("Password: " + HidePassword(passWord));
            Console.WriteLine("Password has been sent to your registered email. ");
        }

        private string HidePassword(string password)
        {
            //Hiding all except the first and last characters
            if(passWord.Length > 2)
            {
                string firstChar = passWord.Substring(0, 1);
                string lastChar = passWord.Substring(passWord.Length - 1);
                string hiddenChars = new string('*', passWord.Length - 2);
                return firstChar + hiddenChars + lastChar;
            }
            else
            {
                return password;
            }
        }
        public string GetPassword()
        {
            return passWord;
        }
    }
}
