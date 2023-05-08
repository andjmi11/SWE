using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Elfind.Data.Services
{
    public class KursService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public KursService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            dbContextFactory = dbContextFactory;
        }

        public void dodajKurs(Kurs kurs)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Kursevi.Add(kurs);
                context.SaveChanges();
            }
        }

        public Kurs preuzmiKurs(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Kurs kurs = context.Kursevi.SingleOrDefault(k => k.ID == ID);
                return kurs;
            }
        }

        /*public void azurirajKurs(int ID)
        {

        }*/
        public void obrisiKurs(int ID)
        {
            Kurs kurs = preuzmiKurs(ID);
            if(kurs == null)
            {
                throw new Exception("Kurs sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(kurs);
                context.SaveChanges();
            }
        }
    }
}
