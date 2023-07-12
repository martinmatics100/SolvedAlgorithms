using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp
{
    internal class BankMenu
    {
        public string choice;
        public void BankMenuFunc()
        {

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("WHAT WOULD YOU LIKE TO DO TODAY");
            Console.WriteLine("-----------------------------------------------------");
           
            
            Console.WriteLine("1. CREATE ANOTHER ACCOUNT");
            Console.WriteLine();
            Console.WriteLine("2. DEPOSIT");
            Console.WriteLine();
            Console.WriteLine("3. WITHDRAW");
            Console.WriteLine();
            Console.WriteLine("4. TRANSFER");
            Console.WriteLine();
            Console.WriteLine("5. CHECK BALANCE");
            Console.WriteLine();
            Console.WriteLine("6. CHECK STATEMENT");
            Console.WriteLine();
            Console.WriteLine("ENTER ANY OF THE NUMBERS TO SELECT AN OPTION");
            choice = Console.ReadLine();

            if (choice == "1") 
            {
                var Reg = new Register();
                Reg.RegisterFunc();
            }
            if (choice == "2")
            {
                var deposit = new Deposit();
                deposit.depositFunc();
            }
            if (choice == "3")
            {
                var withdraw = new Withdraw();
                withdraw.withdrawFunc();
            }
        }
    }
}
