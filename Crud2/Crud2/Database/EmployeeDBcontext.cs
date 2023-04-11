using Microsoft.EntityFrameworkCore;
using Crud2.Model;

namespace Crud2.Database
{
    public class EmployeeDBcontext:DbContext
    {
        public EmployeeDBcontext(DbContextOptions options):base(options)
        {

        }

        public DbSet<employee> Employees { get; set; }
        public DbSet<empsalary> EmployeesSalary { get; set; }
    }
}
