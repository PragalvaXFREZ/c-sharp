namespace StudentCrud_1318.Models;

// Entity: one row of the Students table.
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string Gender { get; set; } = "";
    public decimal Salary { get; set; }
}
