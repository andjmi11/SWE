using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ZgradaService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public ZgradaService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajZgradu(Zgrada zgrada)
        {
            using(var context = dbContextFactory.CreateDbContext()) 
            {
                context.Zgrade.Add(zgrada);
                context.SaveChanges();
            }
        }

        public Zgrada preuzmiZgradu(int ID) 
        {
            using(var context = dbContextFactory.CreateDbContext())
            {
                Zgrada zgrada = context.Zgrade.SingleOrDefault(z => z.ID == ID);
                return zgrada;
            }
        }

        public void azurirajZgradu(int ID, TipZgrade tip)
        {
            Zgrada zgrada = preuzmiZgradu(ID);
            if(zgrada == null) 
            {
                throw new Exception("Zgrada sa datim ID-jem ne postoji!");
            }
            zgrada.Tip = tip;
            using(var context = dbContextFactory.CreateDbContext())
            {
                context.Update(zgrada);
                context.SaveChanges();
            }
        }

        public void obrisiZgradu(int ID)
        {
            Zgrada zgrada = preuzmiZgradu(ID);
            if (zgrada == null)
            {
                throw new Exception("Zgrada sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(zgrada);
                context.SaveChanges();
            }
        }
    }
}
