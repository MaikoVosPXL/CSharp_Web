using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit.Models;
using System.Collections.Generic;

namespace MvcGroentenEnFruit.Data
{
    public class GFDbContext : DbContext
    {
        public GFDbContext(DbContextOptions<GFDbContext> options) : base(options)
        {
        }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<AankoopOrder> AankoopOrders { get; set; }
        public DbSet<VerkoopOrder> VerkoopOrders { get; set; }
    }
}

