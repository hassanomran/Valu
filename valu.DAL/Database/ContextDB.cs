using valu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.DAL.Database
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<Employee> employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable(nameof(Employee));
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(e => e.Identification).HasMaxLength(50).IsRequired(true);
                entity.Property(e => e.mobileNumber).HasMaxLength(20).IsRequired(true);
                entity.Property(e => e.Position).HasMaxLength(40).IsRequired(true);

            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable(nameof(Department));
                entity.Property(e => e.Name).HasMaxLength(20).IsRequired(true);
                entity.Property(e => e.Details).HasMaxLength(300).IsRequired(true);
            });
            modelBuilder.Entity<Department>()
          .HasKey(d => d.Id); 

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id); 

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees) 
                .WithOne(e => e.Department) 
                .HasForeignKey(e => e.DepartmentID); 
        }
    }
}