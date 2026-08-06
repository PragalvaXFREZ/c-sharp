using Microsoft.EntityFrameworkCore;

namespace EmployeeSalaryAggregate_1318;

internal static class Program
{
    private static void Main()
    {
        string databasePath = Path.Combine(
            AppContext.BaseDirectory,
            "employee_salary_lab3.db");

        var options = new DbContextOptionsBuilder<EmployeeContext>()
            .UseSqlite($"Data Source={databasePath}")
            .Options;

        using var db = new EmployeeContext(options);

        // Recreate this exercise-only database so every run uses exactly five records.
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        db.Employees.AddRange(
            new Employee { Name = "Aarav", Address = "Kathmandu", Salary = 45_000 },
            new Employee { Name = "Bina", Address = "Pokhara", Salary = 72_000 },
            new Employee { Name = "Chirag", Address = "Lalitpur", Salary = 58_000 },
            new Employee { Name = "Diksha", Address = "Bhaktapur", Salary = 81_000 },
            new Employee { Name = "Eshan", Address = "Kathmandu", Salary = 69_000 });
        db.SaveChanges();

        List<Employee> employeesBySalary = db.Employees
            .OrderByDescending(employee => employee.Salary)
            .ToList();

        int aggregateSalary = employeesBySalary.Sum(employee => employee.Salary);

        Console.WriteLine($"Aggregate salary: {aggregateSalary:N0}");
        Console.WriteLine("\nEmployees in descending order of salary:");

        foreach (Employee employee in employeesBySalary)
        {
            Console.WriteLine(
                $"{employee.Id}: {employee.Name}, {employee.Address}, {employee.Salary:N0}");
        }
    }
}
