using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AhmerMYWebDemo.Models
{
    public class MyDbContext : DbContext
    {
public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public  DbSet<Category> categories { get; set; }   
        public DbSet<Product> products { get; set; }

    }
}
