using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ZgradaService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public ZgradaService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajZgradu(Zgrada zgrada)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Zgrade.Add(zgrada);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Zgrada> PreuzmiZgradu(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Zgrada zgrada = await context.Zgrade.Include(x=>x.Spratovi).Include(x=>x.Prostorije).SingleOrDefaultAsync(z => z.ID == ID);
                    return zgrada;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajZgradu(int ID, string tip)
        {
            try
            {
                Zgrada zgrada = await PreuzmiZgradu(ID);
                if (zgrada == null)
                {
                    throw new Exception("Zgrada sa datim ID-jem ne postoji!");
                }
                zgrada.Tip = tip;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(zgrada);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiZgradu(int ID)
        {
            try
            {
                Zgrada zgrada = await PreuzmiZgradu(ID);
                if (zgrada == null)
                {
                    throw new Exception("Zgrada sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(zgrada);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Zgrada>> VratiSveZgrade()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Zgrada> zgrade = await context.Zgrade.Include(x => x.Spratovi).Include(x => x.Prostorije).ToListAsync();
                    return zgrade;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Zgrada>();
            }
        }

    }
}
