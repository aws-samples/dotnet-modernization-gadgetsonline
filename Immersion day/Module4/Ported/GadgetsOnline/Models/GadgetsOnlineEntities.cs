using Microsoft.EntityFrameworkCore;

namespace GadgetsOnline.Models
{
    public class GadgetsOnlineEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { /* Use Configuration from static ConfigurationManager to access connection string in appsettings.json. Example below: optionsBuilder.UseSqlServer(ConfigurationManager.Configuration.GetConnectionString("CONNECTIONSTRINGNAME")); */
            base.OnConfiguring(optionsBuilder);
        }
    }
}