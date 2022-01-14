using Microsoft.EntityFrameworkCore;
using ASP.NETMVC.Models;
namespace ASP.NETMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<EmployeeLeaves> EmployeeLeaves { get; set; }
        public DbSet<AppliedLeaves> AppliedEmpLeaves { get; set; }
 
    }
}
