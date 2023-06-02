using Microsoft.EntityFrameworkCore;

namespace AhmerMYWebDemo.Models
{
    public class MyDbContext : DbContext
    {





        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Employees> ObjEmployees { get; set; }
        public  DbSet<ESalary> Salary { get; set; }

    }
}
