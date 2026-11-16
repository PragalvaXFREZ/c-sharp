using Microsoft.EntityFrameworkCore;

namespace EmployeeFilter_1318.Models;

public class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string path = Path.Combine(AppContext.BaseDirectory,
            "employee_filter_lab3.db");
        options.UseSqlite($"Data Source={path}");
    }
}
