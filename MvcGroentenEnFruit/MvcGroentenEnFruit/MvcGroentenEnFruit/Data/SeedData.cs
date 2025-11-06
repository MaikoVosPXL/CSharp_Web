using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit.Models;

namespace MvcGroentenEnFruit.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            try
            {
                using (var scope = app.Services.CreateScope())
                {
                
                    var context = scope.ServiceProvider.GetRequiredService<GFDbContext>();
                    if(context.Database.CanConnect())
                    { 
                        if(!context.Artikels.Any())
                        {
                            var sla = new Artikel();
                            sla.ArtikelNaam = "Ijsberg sla";
                            context.Artikels.Add(sla);
                            var tomaat = new Artikel();
                            tomaat.ArtikelNaam = "Roma tomaat";
                            context.Artikels.Add(tomaat);
                            var wortel = new Artikel() ;
                            wortel.ArtikelNaam = "Wortel";
                            context.Artikels.Add(wortel);
                            context.SaveChanges();

                        }
                    }
                    else
                    { 
                        context.Database.Migrate();
                    }  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
