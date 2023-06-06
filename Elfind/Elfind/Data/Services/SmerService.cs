using Elfind.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class SmerService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public SmerService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajSmer(Smer smer)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Smerovi.Add(smer);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Smer> PreuzmiSmer(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Smer smer = await context.Smerovi.SingleOrDefaultAsync(s => s.ID == ID);
                    return smer;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajSmer(int ID, string naziv)
        {
            try
            {
                Smer smer = await PreuzmiSmer(ID);
                if (smer == null)
                {
                    throw new Exception("Smer sa datim ID-jem ne postoji!");
                }
                smer.Naziv = naziv;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(smer);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiSmer(int ID)
        {
            try
            {
                Smer smer = await PreuzmiSmer(ID);
                if (smer == null)
                {
                    throw new Exception("Smer sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(smer);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Smer>> VratiSveSmerove()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Smer> smerovi = await context.Smerovi.ToListAsync();
                    return smerovi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Smer>();
            }
        }

    }
}
