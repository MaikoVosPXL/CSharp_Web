using Microsoft.EntityFrameworkCore;
using PXLHotelDemo.Models;

namespace PXLHotelDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
