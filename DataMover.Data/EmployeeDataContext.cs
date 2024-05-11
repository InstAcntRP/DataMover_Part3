using System;
using System.Collections.Generic;
using DataMover.Model;
using Microsoft.EntityFrameworkCore;

namespace DataMover.Data;

public partial class EmployeeDataContext : DbContext
{
    public EmployeeDataContext()
    {
    }

    public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeDatum> EmployeeData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PR\\SQLEXPRESS;Database=Staging;Trusted_Connection=True;Encrypt=No");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDatum>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.Department).HasMaxLength(250);
            entity.Property(e => e.EmployeeFirstName).HasMaxLength(500);
            entity.Property(e => e.EmployeeLastName).HasMaxLength(500);
            entity.Property(e => e.Role).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
