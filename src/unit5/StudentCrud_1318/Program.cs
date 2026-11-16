using StudentCrud_1318;
using StudentCrud_1318.Models;

// Lab 3, Q1: menu-driven CRUD on a Students table using Entity Framework.
var studentDB = new StudentDB();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Add student");
    Console.WriteLine("2. Display students");
    Console.WriteLine("3. Update student");
    Console.WriteLine("4. Delete student");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your option: ");
    string? option = Console.ReadLine();
    if (option == null || option == "5")
        break;

    switch (option)
    {
        case "1":
        {
            var (name, address, gender, salary) = ReadDetails();
            int id = studentDB.SaveStudent(name, address, gender, salary);
            Console.WriteLine($"Student saved with Id {id}.");
            break;
        }
        case "2":
            Console.WriteLine("Id  Name              Address     Gender      Salary");
            foreach (Student s in studentDB.GetAllStudents())
                Console.WriteLine($"{s.Id,-4}{s.Name,-18}{s.Address,-12}"
                    + $"{s.Gender,-8}{s.Salary,10:0}");
            break;
        case "3":
        {
            Console.Write("Enter student Id to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var (name, address, gender, salary) = ReadDetails();
            bool updated =
                studentDB.UpdateStudent(id, name, address, gender, salary);
            Console.WriteLine(updated
                ? "Student updated successfully."
                : "Student not found.");
            break;
        }
        case "4":
        {
            Console.Write("Enter student Id to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool deleted = studentDB.DeleteStudent(id);
            Console.WriteLine(deleted
                ? "Student deleted successfully."
                : "Student not found.");
            break;
        }
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static (string, string, string, decimal) ReadDetails()
{
    Console.Write("Name: ");
    string name = Console.ReadLine() ?? "";
    Console.Write("Address: ");
    string address = Console.ReadLine() ?? "";
    Console.Write("Gender: ");
    string gender = Console.ReadLine() ?? "";
    Console.Write("Salary: ");
    decimal salary = Convert.ToDecimal(Console.ReadLine());
    return (name, address, gender, salary);
}
