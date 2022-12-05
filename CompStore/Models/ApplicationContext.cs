using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompStore.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Ordercs> Ordercs { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
