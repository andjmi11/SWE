using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class SpratService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public SpratService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajSprat(Sprat sprat)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    sprat.Zgrada = context.Zgrade.SingleOrDefault(s=>s.ID == sprat.Zgrada.ID);
                    context.Spratovi.Add(sprat);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Sprat> PreuzmiSprat(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Sprat sprat = await context.Spratovi.SingleOrDefaultAsync(s => s.ID == ID);
                    return sprat;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajSprat(int ID, string naziv, Zgrada zgrada, string slika)
        {
            try
            {
                Sprat sprat = await PreuzmiSprat(ID);
                if (sprat == null)
                {
                    throw new Exception("Sprat sa datim ID-jem ne postoji!");
                }
                sprat.Naziv = naziv;
                sprat.Zgrada = zgrada;
                sprat.Slika = slika;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(sprat);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiSprat(int ID)
        {
            try
            {
                Sprat sprat = await PreuzmiSprat(ID);
                if (sprat == null)
                {
                    throw new Exception("Sprat sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(sprat);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Sprat>> VratiSveSpratove()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Sprat> spratovi = await context.Spratovi
                        .Include(s=>s.Zgrada)
                        .ToListAsync();
                    return spratovi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Sprat>();
            }
        }

    }
}
