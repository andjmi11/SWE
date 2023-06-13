using Elfind.Data.Model;
using Elfind.Data.Models;
using Elfind.Pages;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class OpcijaService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public OpcijaService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task DodajOpciju(Opcija opcija)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    opcija.Anketa = await context.Objave.SingleOrDefaultAsync(f => f.ID == opcija.Anketa.ID);

                    context.Opcije.Add(opcija);
                    opcija.Anketa.Opcije.Add(opcija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Opcija> PreuzmiOpciju(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Opcija opcija = await context.Opcije.Include(o => o.Anketa).SingleOrDefaultAsync(o => o.ID == ID);
                    return opcija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }
        public async Task AzurirajOpciju(Opcija o)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    //context.Entry(nastavnoOsoblje).State = EntityState.Detached;

                    context.Opcije.Update(o);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Opcija> PreuzmiOpciju(string tekst)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Opcija opcija = await context.Opcije.Include(o => o.Anketa).SingleOrDefaultAsync(o => o.Tekst == tekst);
                    return opcija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public async Task ObrisiOpciju(string tekst)
        {
            try
            {
                Opcija opcija = await PreuzmiOpciju(tekst);
                if (opcija == null)
                {
                    throw new Exception("Opcija ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(opcija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiOpciju(int ID)
        {
            try
            {
                Opcija opcija = await PreuzmiOpciju(ID);
                if (opcija == null)
                {
                    throw new Exception("Opcija sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(opcija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Opcija>> VratiSveOpcije()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Opcija> opcije = await context.Opcije
                        .Include(o=>o.Anketa)
                        .ToListAsync();
                    return opcije;
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
