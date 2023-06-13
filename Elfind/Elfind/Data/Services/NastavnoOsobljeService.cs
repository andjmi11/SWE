using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Elfind.Data.Services
{
    public class NastavnoOsobljeService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public NastavnoOsobljeService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajNastavnoOsobljeAsync(NastavnoOsoblje nastavnoOsoblje)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    nastavnoOsoblje.Kancelarija = context.Prostorije.SingleOrDefault(n => n.ID == nastavnoOsoblje.Kancelarija.ID);
                    context.NastavnoOsoblje.Add(nastavnoOsoblje);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<NastavnoOsoblje> PreuzmiNastavnoOsobljeAsync(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NastavnoOsoblje nastavnoOsoblje = await context.NastavnoOsoblje.SingleOrDefaultAsync(n => n.ID == ID);
                    return nastavnoOsoblje;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public async Task<NastavnoOsoblje> PreuzmiNastavnoOsobljePoKorisnickomImenuAsync(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NastavnoOsoblje n = await context.NastavnoOsoblje.FirstAsync(x => x.KorisnickoIme == korisnickoIme);
                    NastavnoOsoblje nasOsoblje = await context.NastavnoOsoblje.SingleOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);
                    return n;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajNastavnoOsobljeAsync(int ID, string ime, string prezime, string korisnickoIme, string tip, Prostorija kancelarija)
        {
            try
            {
                NastavnoOsoblje nastavnoOsoblje = await PreuzmiNastavnoOsobljeAsync(ID);
                if (nastavnoOsoblje == null)
                {
                    throw new Exception("Nastavno osoblje sa datim ID-jem ne postoji!");
                }
                nastavnoOsoblje.Ime = ime;
                nastavnoOsoblje.Prezime = prezime;
                nastavnoOsoblje.KorisnickoIme = korisnickoIme;
                nastavnoOsoblje.Tip = tip;
                nastavnoOsoblje.Kancelarija = kancelarija;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.NastavnoOsoblje.Update(nastavnoOsoblje);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiNastavnoOsobljeAsync(int ID)
        {
            try
            {
                NastavnoOsoblje nastavnoOsoblje = await PreuzmiNastavnoOsobljeAsync(ID);
                if (nastavnoOsoblje == null)
                {
                    throw new Exception("Nastavno osoblje sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.NastavnoOsoblje.Remove(nastavnoOsoblje);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<NastavnoOsoblje>> VratiSveNastavnikeAsync()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<NastavnoOsoblje> nastavnoOsoblje = await context.NastavnoOsoblje
                        .Include(n=>n.Kancelarija)
                        .ToListAsync();
                    return nastavnoOsoblje;
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
