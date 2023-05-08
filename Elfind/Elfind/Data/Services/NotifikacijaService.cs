using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class NotifikacijaService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public NotifikacijaService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajNotifikaciju(Notifikacija notifikacija)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Notifikacije.Add(notifikacija);
                context.SaveChanges();
            }
        }

        public Notifikacija preuzmiNotifikaciju(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Notifikacija notifikacija = context.Notifikacije.SingleOrDefault(n => n.ID == ID);
                return notifikacija;
            }
        }

        /*public void azurirajNotifikaciju(int ID)
        {

        }*/

        public void obrisiNotifikaciju(int ID)
        {
            Notifikacija notifikacija = preuzmiNotifikaciju(ID);
            if(notifikacija == null)
            {
                throw new Exception("Notifikacija sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(notifikacija);
                context.SaveChanges();
            }
        }
    }
}
