namespace BANK_CONSOLE_APP
{
    internal class Withdrawal : Registration
    {
        public int Amount;

        public void withdrawFunction()
        {
            Console.Clear();
            Console.WriteLine("WITHDRAW FUNDS");
            Console.WriteLine();

            string accountNumber;
            Customer customer;

            while (true)
            {
                Console.Write("Enter account number: ");
                accountNumber = Console.ReadLine()!;

                customer = ValidateAccountNumber(accountNumber);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number. Please try again.");
                    continue;
                }
                else
                {
                    break;
                }
            }

            int amount;

            while (true)
            {
                Console.Write("Enter amount to withdraw: ");
                string amountInput = Console.ReadLine()!;

                if (!int.TryParse(amountInput, out amount))
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                    continue;
                }

                break;
            }

            if (customer.AccountType == "Savings" && (customer.Balance - amount) < 1000)
            {
                Console.WriteLine("Insufficient balance. Minimum balance requirement for a savings account is 1000.");
                Console.ReadLine();
                return;
            }
            if (amount > customer.Balance)
            {
                Console.WriteLine("Insufficient balance.");
                Console.ReadLine();
                return;
            }

            customer.Balance -= amount;

            Console.WriteLine($"Your new balance is: {customer.Balance}");
            Console.WriteLine();
            Console.WriteLine("SEE YOUR UPDATES BELOW");

            Console.WriteLine($"FirstName: {customer.FirstName}");
            Console.WriteLine($"LastName: {customer.LastName}");
            Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
            Console.WriteLine($"AccountType: {customer.AccountType}");
            Console.WriteLine($"Balance: {customer.Balance}");

            Console.WriteLine("---------------------------------------------------------------");

            // Add withdrawal transaction to the account transaction history
            customer.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Withdrawal",
                Amount = amount,
                Balance = customer.Balance
            });
            Console.WriteLine("Enter 1 to go back to BankMenu");
            string choice = Console.ReadLine()!;

            while (choice != "1")
            {
                Console.WriteLine("Invalid input. Please enter 1 to go back to BankMenu");
                choice = Console.ReadLine()!;
            }

            var menu = new BankMenu();
            menu.BankMenuFunction();
        }

        private Customer ValidateAccountNumber(string accountNumber)
        {
            foreach (var item in customers)
            {
                if (item.AccountNumber == accountNumber)
                {
                    return item;
                }
            }

            return null!;
        }
    }
}