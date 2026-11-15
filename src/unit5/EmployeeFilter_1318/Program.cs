using EmployeeFilter_1318.Models;

namespace EmployeeFilter_1318;

// Lab 3, Q3: select employees whose salary is greater than 50000
// and whose address is Kathmandu, using Entity Framework.
internal class Program
{
    static void Main()
    {
        using var db = new EmployeeContext();

        // Start from a fresh table so every run shows the same sample data.
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        db.Employees.AddRange(
            NewEmployee("Aarav Shrestha", "Kathmandu", 65000),
            NewEmployee("Bina Gurung", "Pokhara", 72000),
            NewEmployee("Chirag Thapa", "Kathmandu", 48000),
            NewEmployee("Diksha Karki", "Kathmandu", 81000),
            NewEmployee("Eshan Rai", "Lalitpur", 55000),
            NewEmployee("Firoj Ansari", "Kathmandu", 50000));
        db.SaveChanges();

        Console.WriteLine("All employees:");
        Print(db.Employees.OrderBy(e => e.Id).ToList());

        // LINQ query: EF translates this Where into a SQL WHERE clause.
        List<Employee> selected = db.Employees
            .Where(e => e.Salary > 50000 && e.Address == "Kathmandu")
            .OrderBy(e => e.Id)
            .ToList();

        Console.WriteLine();
        Console.WriteLine("Employees with salary > 50000 and address Kathmandu:");
        Print(selected);
    }

    static Employee NewEmployee(string name, string address, decimal salary) =>
        new Employee { Name = name, Address = address, Salary = salary };

    static void Print(List<Employee> employees)
    {
        Console.WriteLine($"{"Id",-4}{"Name",-18}{"Address",-12}{"Salary",10}");
        foreach (Employee e in employees)
            Console.WriteLine(
                $"{e.Id,-4}{e.Name,-18}{e.Address,-12}{e.Salary,10:0}");
    }
}
