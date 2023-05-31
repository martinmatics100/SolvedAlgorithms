using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleBankProgram
{
    public class Registration
    {
        //fields or memebers of the Registration Class
        protected string fullName { get; set; }
        protected string email { get; set; }
        protected string passWord { get; set; }
        protected string accountNumber { get; private set; }
        protected string accountType { get; private set; }
        protected decimal accountBalance { get; private set; }

        public Registration()
        {
            fullName = "";
            email = "";
            passWord = "";
            accountNumber = "";
            accountType = "Saving Account"; //default account type
            accountBalance = 0;
        }

        //Constructors of the field or members
        public Registration(string fullname, string email, string passWord, string accountNumber, string accountType, decimal accountBalance)
        {
            this.fullName = fullname;
            this.email = email;
            this.passWord = passWord;
            this.accountNumber = accountNumber;
            this.accountType = accountType;
            this.accountBalance = accountBalance;
        }

        public void Register()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to ESKIMO Console Bank App!");
            Console.WriteLine("Your gateway to convenient and secure banking services.");
            Console.WriteLine();
            Console.WriteLine("|-------------------------------------------------------|");
            Console.WriteLine("|    PLEASE REGISTER TO GENERATE YOUR ACCOUNT DETAILS   |");
            Console.WriteLine("|-------------------------------------------------------|");
            Console.WriteLine();
            Console.Write("ENTER YOUR FULL NAME: ");
            fullName = Console.ReadLine().ToUpper();

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
            Console.WriteLine("Which type of account do you want to open :");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.Write("Enter your choice: ");
            string accountChoice = Console.ReadLine()!;
            string enteredAmount;

            if (accountChoice == "1")
            {
                accountType = "Savings Account";

                Console.WriteLine("A deposit is needed to open such account (must not be less than 1000)");
                Console.WriteLine("please enter an amount");
                enteredAmount = Console.ReadLine();
                while (!decimal.TryParse(enteredAmount, out decimal depositAmount) || depositAmount < 1000)
                {
                    Console.WriteLine("Invalid amount. Please enter an amount greater than or equal to 1000: ");
                    enteredAmount = Console.ReadLine();
                }
                    decimal cleanAmount = decimal.Parse(enteredAmount);
                    accountBalance += cleanAmount;
                    Account accounts = new Account(fullName, accountType, accountNumber, accountBalance);
                    BankMenu.accounts.Add(accounts);
                    Console.WriteLine($"You have succefully added {cleanAmount} naira to your new account => {accountNumber} ");
            }
            else if (accountChoice == "2")
            {
                accountType = "Current Account";

                Console.WriteLine("A deposit is needed to open such account (must not be less than 5000)");
                Console.WriteLine("please enter an amount");
                enteredAmount = Console.ReadLine()!;
                while (!decimal.TryParse(enteredAmount, out decimal depositAmount) || depositAmount < 5000)
                {
                    Console.WriteLine("Invalid amount. Please enter an amount greater than or equal to 5000: ");
                    enteredAmount = Console.ReadLine();
                }
                    decimal cleanAmount = decimal.Parse(enteredAmount);
                    accountBalance += cleanAmount;
                    Account account = new Account(fullName, accountType, accountNumber, accountBalance);
                    BankMenu.accounts.Add(account);
                    Console.WriteLine($"You have succefully added {cleanAmount} naira to your new account => {accountNumber} ");
            }
            else
            {
                Console.WriteLine("Invalid choice. Defaulting to Savings Account.");
            }

            //ChooseAccountType();

            GenerateAccountNumber();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ==> REGISTRATION SUCCESSFUL! ");
            PrintDetails(); // this displays customers details
            Console.WriteLine();

            Console.WriteLine("Enter Y to continue or N to stop: ");
            string choice = Console.ReadLine()!;

            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Login login = new Login(fullName, email, passWord, accountNumber, accountType, accountBalance);
                login.Auntenticator();
            }
            Console.ReadKey();
            Console.WriteLine("==================================================");

        }

            private void GenerateAccountNumber()
            {
                Random random = new Random();
                accountNumber = Convert.ToString(random.Next(1000000000, 2000000000));
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
                Console.WriteLine();
                Console.WriteLine("|----------------------------|");
                Console.WriteLine("|    YOUR ACCOUNT DETAILS    |");
                Console.WriteLine("|----------------------------|");
                Console.WriteLine();
                Console.WriteLine("FULL NAME: " + fullName);
                Console.WriteLine("EMAIL: " + email);
                Console.WriteLine("ACCOUNT NUMBER: " + accountNumber);
                Console.WriteLine("ACCOUNT TYPE: " + accountType);
                Console.WriteLine("PASSWORD: " + HidePassword(passWord));
                Console.WriteLine("Password has been sent to your registered email. ");
            }

            private string HidePassword(string password)
            {
                //Hiding all except the first and last characters
                if (passWord.Length > 2)
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