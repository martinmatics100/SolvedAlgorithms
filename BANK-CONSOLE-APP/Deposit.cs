namespace BANK_CONSOLE_APP
{
    internal class Deposit : Registration
    {
        public int Amount { get; set; }

        public void depositFunction()
        {
            Console.Clear();
            Console.WriteLine("DEPOSIT FUNDS");
            Console.WriteLine();

            // Prompt user to enter the account number
            string accountNumber;
            Customer customer;
            bool isValidAccountNumber = false;

            do
            {
                Console.Write("Enter account number: ");
                accountNumber = (Console.ReadLine())!;
                 
                
                // Validate the entered account number
                customer = ValidateAccountNumber(accountNumber);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number. Please try again.");
                }
                else
                {
                    isValidAccountNumber = true;
                }
            } while (!isValidAccountNumber);

            int amount;

            while (true)
            {
                Console.Write("Enter amount to deposit: ");
                string amountInput = Console.ReadLine()!;

                if (!int.TryParse(amountInput, out amount))
                {
                    Console.WriteLine("Invalid amount. Please enter a valid amount.");
                    continue;
                }

                break;
            }

            customer!.Balance += amount;

            Console.WriteLine($"Your new balance is: {customer.Balance}");
            Console.WriteLine();
            Console.WriteLine("SEE YOUR UPDATES BELOW");

            // Display the customer's details
            Console.WriteLine($"FirstName: {customer.FirstName}");
            Console.WriteLine($"LastName: {customer.LastName}");
            Console.WriteLine($"Fullname: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
            Console.WriteLine($"AccountType: {customer.AccountType}");
            Console.WriteLine($"Balance: {customer.Balance}");

            Console.WriteLine("---------------------------------------------------------------");

            // Add deposit transaction to the account transaction history
            customer.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Deposit",
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
            // Check if the account number consists only of digits
            if (!int.TryParse(accountNumber, out _))
            {
                return null!; // Return null if the account number contains non-digit characters
            }

            // Search for the customer with the provided account number
            foreach (var item in customers)
            {
                if (item.AccountNumber == accountNumber)
                {
                    return item; // Return the customer if the account number is valid
                 }
            }

               return null!; // Return null if the account number is not found
       }
    }
}