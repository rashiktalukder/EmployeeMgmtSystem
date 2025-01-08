using EmployeeMgmtSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgmtSystem.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one to many relationship between Department and Employee
            /*modelBuilder.Entity<Department>().HasMany(dept=>dept.Employees)
                .WithOne(emp=>emp.Department)
                .HasForeignKey(emp=>emp.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);*/

            // Configure one to one relationship for Manager in Department
            modelBuilder.Entity<Department>().HasOne(dept => dept.Manager)
                .WithOne()
                .HasForeignKey<Department>(dept => dept.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
