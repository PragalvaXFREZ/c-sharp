using StudentCrud_1318.Models;

namespace StudentCrud_1318;

// CRUD operations on the Students table through Entity Framework.
public class StudentDB
{
    public StudentDB()
    {
        using var db = new StudentContext();
        db.Database.EnsureCreated();
    }

    // Create
    public int SaveStudent(string name, string address, string gender,
        decimal salary)
    {
        using var db = new StudentContext();
        var student = new Student
        {
            Name = name,
            Address = address,
            Gender = gender,
            Salary = salary
        };
        db.Students.Add(student);
        int rows = db.SaveChanges();
        Console.WriteLine($"Rows affected: {rows}");
        return student.Id; // EF fills in the generated Id after SaveChanges
    }

    // Read
    public List<Student> GetAllStudents()
    {
        using var db = new StudentContext();
        return db.Students.OrderBy(s => s.Id).ToList();
    }

    // Update
    public bool UpdateStudent(int id, string name, string address, string gender,
        decimal salary)
    {
        using var db = new StudentContext();
        Student? student = db.Students.Find(id);
        if (student == null)
            return false;

        student.Name = name;
        student.Address = address;
        student.Gender = gender;
        student.Salary = salary;
        db.SaveChanges();
        return true;
    }

    // Delete
    public bool DeleteStudent(int id)
    {
        using var db = new StudentContext();
        Student? student = db.Students.Find(id);
        if (student == null)
            return false;

        db.Students.Remove(student);
        db.SaveChanges();
        return true;
    }
}
