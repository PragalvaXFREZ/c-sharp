using DatabaseWithCode_1318.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseWithCode_1318;

public sealed class StudentDB
{
    private readonly DbContextOptions<DbMydatabaseUnit5Context> options;

    public StudentDB(DbContextOptions<DbMydatabaseUnit5Context> options)
    {
        this.options = options;
    }

    public void DeleteStudent(int id)
    {
        using var db = new DbMydatabaseUnit5Context(options);
        TbStudent student = FindStudent(db, id);

        db.TbStudents.Remove(student);
        db.SaveChanges();
    }

    public void UpdateStudent(
        string name,
        string address,
        string gender,
        decimal salary,
        int id)
    {
        using var db = new DbMydatabaseUnit5Context(options);
        TbStudent student = FindStudent(db, id);

        student.Name = name;
        student.Address = address;
        student.Gender = gender;
        student.Salary = salary;
        db.SaveChanges();
    }

    public List<TbStudent> LoadStudent()
    {
        using var db = new DbMydatabaseUnit5Context(options);
        return db.TbStudents.OrderBy(student => student.Id).ToList();
    }

    public TbStudent SaveStudent(
        string name,
        string address,
        string gender,
        decimal salary)
    {
        using var db = new DbMydatabaseUnit5Context(options);
        var student = new TbStudent
        {
            Name = name,
            Address = address,
            Gender = gender,
            Salary = salary
        };

        db.TbStudents.Add(student);
        db.SaveChanges();
        return student;
    }

    private static TbStudent FindStudent(DbMydatabaseUnit5Context db, int id)
    {
        return db.TbStudents.SingleOrDefault(student => student.Id == id)
            ?? throw new InvalidOperationException($"Student {id} was not found.");
    }
}
