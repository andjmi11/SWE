using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Elfind.Data.Services
{
    public class KursService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public KursService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            dbContextFactory = dbContextFactory;
        }

        public async Task DodajKursAsync(Kurs kurs)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Kursevi.Add(kurs);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Kurs> PreuzmiKursAsync(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Kurs kurs = await context.Kursevi.SingleOrDefaultAsync(k => k.ID == ID);
                    return kurs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public async Task AzurirajKursAsync(int ID, string Naziv, int Godina)
        {
            try
            {
                Kurs kurs = await PreuzmiKursAsync(ID);
                if (kurs == null)
                {
                    throw new Exception("Kurs sa datim ID-jem ne postoji!");
                }
                kurs.Naziv = Naziv;
                kurs.Godina = Godina;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(kurs);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiKursAsync(int ID)
        {
            try
            {
                Kurs kurs = await PreuzmiKursAsync(ID);
                if (kurs == null)
                {
                    throw new Exception("Kurs sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(kurs);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Kurs>> VratiSveKurseveAsync()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Kurs> kursevi = await context.Kursevi.ToListAsync();
                    return kursevi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Kurs>(); 
            }
        }

    }
}
