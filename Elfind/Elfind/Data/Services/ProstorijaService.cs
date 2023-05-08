using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ProstorijaService
    {

        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public ProstorijaService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajProstoriju(Prostorija prostorija)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Prostorije.Add(prostorija);
                context.SaveChanges();
            }
        }

        public Prostorija preuzmiProstoriju(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Prostorija prostorija = context.Prostorije.SingleOrDefault(p => p.ID == ID);
                return prostorija;
            }
        }

        public void azurirajProstoriju(int ID, string oznaka)
        {
            Prostorija prostorija = preuzmiProstoriju(ID);
            if (prostorija == null)
            {
                throw new Exception("Prostorija sa datim ID-jem ne postoji!");
            }
            prostorija.Oznaka = oznaka;
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Update(prostorija);
                context.SaveChanges();
            }
        }

        public void obrisiProstoriju(int ID)
        {
            Prostorija prostorija = preuzmiProstoriju(ID);
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
    }
}
