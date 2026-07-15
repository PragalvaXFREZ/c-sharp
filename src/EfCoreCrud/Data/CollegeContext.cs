using EfCoreCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCrud.Data;

public class CollegeContext(DbContextOptions<CollegeContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
}
