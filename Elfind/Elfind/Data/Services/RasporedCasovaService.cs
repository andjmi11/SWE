using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class RasporedCasovaService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public RasporedCasovaService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajRasporedCasova(RasporedCasova rasporedCasova)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.ResporediCasova.Add(rasporedCasova);
                context.SaveChanges();
            }
        }

        public RasporedCasova preuzmiRasporedCasova(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                RasporedCasova rasporedCasova = context.ResporediCasova.SingleOrDefault(r => r.ID == ID);
                return rasporedCasova;
            }
        }

        /*public void azurirajRasporedCasova(int ID)
        {

        }*/

        public void obrisiRasporedCasova(int ID)
        {
            RasporedCasova rasporedCasova = preuzmiRasporedCasova(ID);
            if (rasporedCasova == null)
            {
                throw new Exception("Raspored casova sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(rasporedCasova);
                context.SaveChanges();
            }
        }
    }
}
