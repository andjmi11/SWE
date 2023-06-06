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

        public void DodajProstoriju(Prostorija prostorija)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    prostorija.Sprat = context.Spratovi.SingleOrDefault(p=>p.ID==prostorija.Sprat.ID);
                    prostorija.PripadaZgradi = context.Zgrade.SingleOrDefault(p => p.ID == prostorija.PripadaZgradi.ID);
                  
                    context.Prostorije.Add(prostorija);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Prostorija PreuzmiProstoriju(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Prostorija prostorija = context.Prostorije.SingleOrDefault(p => p.ID == ID);
                    return prostorija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public Prostorija PreuzmiProstorijuPoOznaci(string oznaka)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Prostorija prostorija = context.Prostorije.SingleOrDefault(p => p.Oznaka == oznaka);
                    return prostorija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void AzurirajProstoriju(int ID, string oznaka, Sprat sprat, float downRightX, float downRightY, float leftUpX, float leftUpY, int kapacitet, TipP tipProstorije, Zgrada pripadaZgradi)
        {
            try
            {
                Prostorija prostorija = PreuzmiProstoriju(ID);
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
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ObrisiProstoriju(int ID)
        {
            try
            {
                Prostorija prostorija = PreuzmiProstoriju(ID);
                if (prostorija == null)
                {
                    throw new Exception("Prostorija sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(prostorija);
                    context.SaveChanges();
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
    }
}