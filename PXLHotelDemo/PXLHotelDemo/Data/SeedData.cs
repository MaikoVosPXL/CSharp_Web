using PXLHotelDemo.Models;
using System.Numerics;

namespace PXLHotelDemo.Data
{
    public class SeedData
    {
        public static void EnsureData(WebApplication app)
        {

            using (var scope = app.Services.CreateScope())
            {
                using (AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    if (!context.HotelRooms.Any())
                    {

                        foreach (Hotel hotel in DefaultData.Hotels)
                        {
                            context.Hotels.Add(hotel);
                        }
                        context.SaveChanges();
                        foreach (HotelRoom hotelRoom in DefaultData.HotelRooms)
                        {
                            context.HotelRooms.Add(hotelRoom);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
