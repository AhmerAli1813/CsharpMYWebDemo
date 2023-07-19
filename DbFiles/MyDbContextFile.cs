using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.DbFiles
{
    public class MyDbContextFile : DbContext
    {
        public MyDbContextFile(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Users> users { get; set; }
    }
}
