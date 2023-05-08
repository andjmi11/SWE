using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class CasService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public CasService(IDbContextFactory<ElfindDbContext> dbContextFactory) 
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajCas(Cas cas)
        {
            using(var context = dbContextFactory.CreateDbContext())
            {
                context.Casovi.Add(cas);
                context.SaveChanges();
            }
        }

        public Cas preuzmiCas(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Cas cas = context.Casovi.SingleOrDefault(c  => c.ID == ID);
                return cas;
            }
        }

        //public void azurirajCas(int ID)
        //{

        //}

        public void obrisiCas(int ID)
        {
            Cas cas = preuzmiCas(ID);
            if(cas == null)
            {
                throw new Exception("Cas sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(cas);
                context.SaveChanges();
            }
        }
    }
}
