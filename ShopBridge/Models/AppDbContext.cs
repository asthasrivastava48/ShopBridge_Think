using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Models
{
    public class AppDbContext : DbContext
    { 

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    public DbSet<Item> items { get; set; }

    }
}
