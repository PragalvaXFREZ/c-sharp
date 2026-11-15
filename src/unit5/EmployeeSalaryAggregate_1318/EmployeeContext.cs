using Microsoft.EntityFrameworkCore;

namespace EmployeeSalaryAggregate_1318;

public sealed class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
}
