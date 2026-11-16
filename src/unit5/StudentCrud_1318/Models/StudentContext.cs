using Microsoft.EntityFrameworkCore;

namespace StudentCrud_1318.Models;

// DbContext: the session with the database. Each DbSet maps to a table.
public class StudentContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string path = Path.Combine(AppContext.BaseDirectory,
            "student_lab3.db");
        options.UseSqlite($"Data Source={path}");
    }
}
