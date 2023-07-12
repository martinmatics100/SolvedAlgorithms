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

            // Prompt user to enter the account number
            Console.Write("Enter account number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            // Validate the entered account number
            Customer customer = ValidateAccountNumber(accountNumber);

            if (customer == null)
            {
                Console.WriteLine("Invalid account number. Please try again.");
                Console.ReadLine(); // Add a pause before returning to the BankMenu
                return;
            }

            Console.Write("Enter amount to withdraw: ");
            Amount = Convert.ToInt32(Console.ReadLine());

            // Check if the account type is savings
            if (customer.AccountType == "Savings" && (customer.Balance - Amount) < 1000)
            {
                Console.WriteLine("Insufficient balance. Minimum balance requirement for savings account is 1000.");
                Console.ReadLine(); // Add a pause before returning to the BankMenu
                return;
            }

            // Update the balance of the customer
            customer.Balance -= Amount;

            customer.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Withdrawal",
                Amount = Amount,
                Balance = customer.Balance,
            });

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

        private Customer ValidateAccountNumber(int accountNumber)
        {
            // Search for the customer with the provided account number
            foreach (var item in customers)
            {
                if (item.AccountNumber == accountNumber)
                {
                    return item; // Return the customer if the account number is valid
                }
            }

            return null; // Return null if the account number is not found
        }
    }
}