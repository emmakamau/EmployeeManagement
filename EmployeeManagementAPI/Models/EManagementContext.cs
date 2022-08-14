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
    } 
}
