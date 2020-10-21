using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6
{
    public class AppContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public AppContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
