using Employee_Record_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Record_Management_System.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
