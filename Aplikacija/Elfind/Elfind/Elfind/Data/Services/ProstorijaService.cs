using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ProstorijaService
    {

        private IDbContextFactory<ElfindContext> dbContextFactory;

        public ProstorijaService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajProstoriju(Prostorija prostorija)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    prostorija.Sprat = await context.Spratovi.SingleOrDefaultAsync(p => p.ID == prostorija.Sprat.ID);
                    prostorija.PripadaZgradi = await context.Zgrade.SingleOrDefaultAsync(p => p.ID == prostorija.PripadaZgradi.ID);

                    context.Prostorije.Add(prostorija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Prostorija> PreuzmiProstoriju(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Prostorija prostorija = await context.Prostorije.Include(s => s.Sprat)
                        .Include(s => s.PripadaZgradi)
                        .Include(x=>x.NastavnoOsobljeUKancelariji)
                        .Include(x=>x.NastavnoOsobljeR)
                        .SingleOrDefaultAsync(p => p.ID == ID);
                    return prostorija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Prostorija> PreuzmiProstorijuPoOznaci(string oznaka)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Prostorija prostorija = await context.Prostorije
                        .Include(s => s.Sprat)
                        .Include(s => s.PripadaZgradi)
                        .Include(x => x.NastavnoOsobljeUKancelariji)
                        .Include(x => x.NastavnoOsobljeR)
                        .SingleOrDefaultAsync(p => p.Oznaka == oznaka);

                    List<OsobljeProstorijaR> rezNast = await context.OsobljeProstorijaRSpoj
                        .Include(x => x.Prostorija)
                        .Include(x => x.NastavnoOsoblje)
                        .Where(x => x.Prostorija.ID == prostorija.ID).ToListAsync();

                    List<NastavnoOsoblje> osoblje = await context.NastavnoOsoblje
                        .Include(x => x.Kancelarija)
                        .Where(x => x.Kancelarija.ID == prostorija.ID).ToListAsync();

                    prostorija.NastavnoOsobljeR.AddRange(rezNast);
                    prostorija.NastavnoOsobljeUKancelariji.AddRange(osoblje);
                    

                    return prostorija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajProstoriju(int ID, string oznaka, Sprat sprat, float downRightX, float downRightY, float leftUpX, float leftUpY, int kapacitet, TipP tipProstorije, Zgrada pripadaZgradi)
        {
            try
            {
                Prostorija prostorija = await PreuzmiProstoriju(ID);
                if (prostorija == null)
                {
                    throw new Exception("Prostorija sa datim ID-jem ne postoji!");
                }
                prostorija.Oznaka = oznaka;
                prostorija.Sprat = sprat;
                prostorija.TipProstorije = tipProstorije;
                prostorija.PripadaZgradi = pripadaZgradi;
                prostorija.DownRightX = downRightX;
                prostorija.DownRightY = downRightY;
                prostorija.LeftUpX = leftUpX;
                prostorija.LeftUpY = leftUpY;
                prostorija.Kapacitet = kapacitet;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(prostorija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiProstoriju(int ID)
        {
            try
            {
                Prostorija prostorija = await PreuzmiProstoriju(ID);
                if (prostorija == null)
                {
                    throw new Exception("Prostorija sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(prostorija);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Prostorija>> VratiSveProstorije()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Prostorija> prostorije = await context.Prostorije
                        .Include(s => s.Sprat)
                        .Include(s => s.PripadaZgradi)
                        .Include(x => x.NastavnoOsobljeUKancelariji)
                        .Include(x => x.NastavnoOsobljeR)
                        .ToListAsync();
                    return prostorije;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Prostorija>();
            }
        }

        public async Task<List<Prostorija>> VratiSveProstorijePoSpratu(int spratID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Prostorija> prostorije = await context.Prostorije.Include(s => s.Sprat).Include(s => s.PripadaZgradi).Include(x => x.NastavnoOsobljeUKancelariji).Include(x => x.NastavnoOsobljeR)
                        .Where(s => s.Sprat.ID.Equals(spratID))
                        .ToListAsync();
                    return prostorije;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Prostorija>();
            }
        }

        public async Task<List<Prostorija>> VratiSveKancelarije()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Prostorija> prostorije = await context.Prostorije.Include(s => s.Sprat).Include(s => s.PripadaZgradi).Include(x => x.NastavnoOsobljeUKancelariji).Include(x => x.NastavnoOsobljeR)
                        .Where(t => t.TipProstorije.Equals(TipP.Kancelarija))
                        .ToListAsync();
                    return prostorije;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Prostorija>();
            }
        }

        //public List<TipP> VratiSveTipove()
        //{
        //    try
        //    {
        //        using (var context = dbContextFactory.CreateDbContext())
        //        {
        //            List<TipP> tipovi = context.Prostorije.Include(s=> s.ti)
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return new List<TipP>();
        //    }
        //}
    }
}