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
        public void DodajOpciju(Opcija opcija)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    opcija.Anketa = context.Objave.SingleOrDefault(f => f.ID == opcija.Anketa.ID);

                    context.Opcije.Add(opcija);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Opcija PreuzmiOpciju(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Opcija opcija = context.Opcije.SingleOrDefault(o => o.ID == ID);
                    return opcija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public Opcija PreuzmiOpciju(string tekst)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Opcija opcija = context.Opcije.SingleOrDefault(o => o.Tekst == tekst);
                    return opcija;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public void ObrisiOpciju(string tekst)
        {
            try
            {
                Opcija opcija = PreuzmiOpciju(tekst);
                if (opcija == null)
                {
                    throw new Exception("Opcija ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(opcija);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ObrisiOpciju(int ID)
        {
            try
            {
                Opcija opcija = PreuzmiOpciju(ID);
                if (opcija == null)
                {
                    throw new Exception("Opcija sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(opcija);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Opcija> VratiSveOpcije()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Opcija> opcije = context.Opcije
                        .Include(o=>o.Anketa)
                        .ToList();
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
