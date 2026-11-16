using BankCustomer_1318.Models;

namespace BankCustomer_1318;

// Lab 3, Q4: connect to the bank database, insert 5 customer records and
// display the customers whose balance is greater than 50000.
internal class Program
{
    static void Main()
    {
        using var db = new BankContext();

        // Start from an empty customer table so the five inserts never clash.
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        Console.WriteLine("Enter details of 5 customers");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"\nCustomer {i}");
            Console.Write("Account No: ");
            int accountNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Address: ");
            string address = Console.ReadLine() ?? "";
            Console.Write("Balance: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

            db.Customers.Add(new Customer
            {
                AccountNo = accountNo,
                Name = name,
                Address = address,
                Balance = balance
            });
        }
        int rows = db.SaveChanges();
        Console.WriteLine($"\n{rows} records inserted into the customer table.");

        List<Customer> rich = db.Customers
            .Where(c => c.Balance > 50000)
            .OrderBy(c => c.AccountNo)
            .ToList();

        Console.WriteLine("\nCustomers with balance greater than 50000:");
        Console.WriteLine(
            $"{"Account No",-12}{"Name",-18}{"Address",-12}{"Balance",10}");
        foreach (Customer c in rich)
            Console.WriteLine(
                $"{c.AccountNo,-12}{c.Name,-18}{c.Address,-12}{c.Balance,10:0}");
    }
}
