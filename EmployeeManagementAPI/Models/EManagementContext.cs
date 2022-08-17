using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Models
{
    public class EManagementContext : DbContext
    {
        public EManagementContext(DbContextOptions<EManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, DepartmentName = "IT" },
            new Department { Id = 2, DepartmentName = "HR" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "John", JoiningDate = DateTime.Parse("2022-08-05 10:16:23.255").ToUniversalTime(), DepartmentId = 1, PhotoFileName = "john.png" },
            new Employee { Id = 2, Name = "Mary", JoiningDate = DateTime.Parse("2022-10-05 10:16:23.255").ToUniversalTime(), DepartmentId = 2, PhotoFileName = "mary.png" }
        );
    }
}
