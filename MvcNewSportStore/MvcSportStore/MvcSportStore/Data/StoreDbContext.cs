using Microsoft.EntityFrameworkCore;
using MvcSportStore.Models;

namespace MvcSportStore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
