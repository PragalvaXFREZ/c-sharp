using DatabaseWithCode_1318;
using DatabaseWithCode_1318.Models;
using Microsoft.EntityFrameworkCore;

if (args.Length != 1)
{
    Console.Error.WriteLine(
        "Usage: dotnet run --project src/unit5/DatabaseWithCode_1318 -- <database-path>");
    return 1;
}

string databasePath = Path.GetFullPath(args[0]);
if (!File.Exists(databasePath))
{
    Console.Error.WriteLine($"Database not found: {databasePath}");
    return 1;
}

var options = new DbContextOptionsBuilder<DbMydatabaseUnit5Context>()
    .UseSqlite($"Data Source={databasePath}")
    .Options;

var studentDb = new StudentDB(options);

TbStudent savedStudent = studentDb.SaveStudent(
    "Pragalva",
    "Kathmandu",
    "Male",
    50_000m);

Console.WriteLine($"Saved student {savedStudent.Id}.");

studentDb.UpdateStudent(
    "Pragalva",
    "Lalitpur",
    "Male",
    55_000m,
    savedStudent.Id);

Console.WriteLine("Students after update:");
foreach (TbStudent student in studentDb.LoadStudent())
{
    Console.WriteLine(
        $"{student.Id}: {student.Name}, {student.Address}, {student.Gender}, {student.Salary:0.00}");
}

studentDb.DeleteStudent(savedStudent.Id);
Console.WriteLine($"Deleted student {savedStudent.Id}.");

return 0;
