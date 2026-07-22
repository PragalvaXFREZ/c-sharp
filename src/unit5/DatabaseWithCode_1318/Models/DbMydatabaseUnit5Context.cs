using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseWithCode_1318.Models;

public partial class DbMydatabaseUnit5Context : DbContext
{
    public DbMydatabaseUnit5Context(DbContextOptions<DbMydatabaseUnit5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TbStudent> TbStudents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbStudent>(entity =>
        {
            entity.Property(e => e.Salary).HasColumnType("NUMERIC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
