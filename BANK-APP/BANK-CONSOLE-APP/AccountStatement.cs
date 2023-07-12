using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class AccountStatement : Registration
    {
        public void PrintAccountStatement()
        {
            Console.WriteLine("Enter the account number:");
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            
            Customer customer = GetCurrentCustomer(accountNumber);

            if (customer != null)
            {
                Console.WriteLine($"Account Statement for Account Number: {customer.AccountNumber}");
                Console.WriteLine("==========================================");

                Console.WriteLine("Date\t\tDescription\tAmount\tBalance");
                Console.WriteLine("------------------------------------------");

                decimal runningBalance = 0;

                
                foreach (Transaction transaction in customer.Transactions)
                {
                    runningBalance += transaction.Amount;
                    Console.WriteLine($"{transaction.Date.ToShortDateString()}\t{transaction.Description}\t{transaction.Amount}\t{transaction.Balance}");
                }

                Console.WriteLine("==========================================");
            }
            else
            {
                Console.WriteLine("Invalid account number!");
            }
        }

        private Customer GetCurrentCustomer(int accountNumber)
        {

            Customer customer = Registration.customers.FirstOrDefault(c => c.AccountNumber == accountNumber)!;

            return customer;
        }

        private List<Customer> GetCustomers()
        {
           
            List<Customer> customers = new List<Customer>
            {
            };

            return customers;
        }
    }
}
