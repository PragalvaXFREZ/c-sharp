using Microsoft.EntityFrameworkCore;

namespace BankCustomer_1318.Models;

public class BankContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    // Connect to the "bank" database.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string path = Path.Combine(AppContext.BaseDirectory, "bank.db");
        options.UseSqlite($"Data Source={path}");
    }
}
