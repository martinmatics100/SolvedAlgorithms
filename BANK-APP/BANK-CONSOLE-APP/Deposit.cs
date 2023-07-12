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

            Console.Write("Enter amount to deposit: ");
            Amount = Convert.ToInt32(Console.ReadLine());

            // Update the balance of the customer
            customer.Balance += Amount;

            Console.WriteLine($"Your new balance is: {customer.Balance}");
            Console.WriteLine();
            Console.WriteLine("SEE YOUR UPDATES BELOW");

            customer.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Deposit",
                Amount = Amount,
                Balance = customer.Balance
            });

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

            return null!; // Return null if the account number is not found
        }
    }
}