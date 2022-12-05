using Microsoft.EntityFrameworkCore;


namespace CompStore.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Ordercs> Ordercs { get; set; }

        public StoreContext(DbContextOptions<StoreContext> Context) : base(Context)
        {
            Database.EnsureCreated();
        }
        //public DatabaseShow(DbContextOptions<StoreContext> Context): base(Context)
        //{
        //    Database.D
        //}
    }
}
