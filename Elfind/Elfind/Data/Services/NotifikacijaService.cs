using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class NotifikacijaService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public NotifikacijaService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }



        public async Task DodajNotifikacijuAsync(Notifikacija notifikacija)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    notifikacija.Posiljalac = context.NastavnoOsoblje.SingleOrDefault(n => n.ID == notifikacija.Posiljalac.ID);
                    notifikacija.ZaObjavu = context.Objave.SingleOrDefault(n => n.ID == notifikacija.ZaObjavu.ID);
                    context.Notifikacije.Add(notifikacija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Notifikacija> PreuzmiNotifikacijuAsync(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Notifikacija notifikacija = await context.Notifikacije.SingleOrDefaultAsync(n => n.ID == ID);
                    return notifikacija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public async Task ObrisiNotifikacijuAsync(int ID)
        {
            try
            {
                Notifikacija notifikacija = await PreuzmiNotifikacijuAsync(ID);
                if (notifikacija == null)
                {
                    throw new Exception("Notifikacija sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Notifikacije.Remove(notifikacija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Notifikacija>> VratiSveNotifikacijeAsync()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Notifikacija> notifikacije = await context.Notifikacije
                        .Include(n=>n.Posiljalac)
                        .Include(n=>n.ZaObjavu)
                        .ToListAsync();
                    return notifikacije;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }
    }
}
