using Microsoft.EntityFrameworkCore;
using ProductosSA.Entities;

namespace ProductosSA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
