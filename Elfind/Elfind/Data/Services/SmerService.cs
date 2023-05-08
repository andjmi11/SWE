using Elfind.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class SmerService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public SmerService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajSmer(Smer smer)
        {
            using(var context = dbContextFactory.CreateDbContext())
            {
                context.Smerovi.Add(smer);
                context.SaveChanges();
            }
        }

        public Smer preuzmiSmer(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Smer smer = context.Smerovi.SingleOrDefault(s => s.ID == ID);
                return smer;
                
            }
        }

        public void obrisiSmer(int ID)
        {
            Smer smer = preuzmiSmer(ID);
            if(smer == null)
            {
                throw new Exception("Smer sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(smer);
                context.SaveChanges();
            }
        }
    }
}
