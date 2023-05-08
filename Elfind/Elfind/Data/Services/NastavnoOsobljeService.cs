using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Elfind.Data.Services
{
    public class NastavnoOsobljeService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public NastavnoOsobljeService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajNastavnoOsoblje(NastavnoOsoblje nastavnoOsoblje)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.NastavnoOsoblje.Add(nastavnoOsoblje);
                context.SaveChanges();
            }
        }

        public NastavnoOsoblje preuzmiNastavnoOsoblje(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                NastavnoOsoblje nastavnoOsoblje = context.NastavnoOsoblje.SingleOrDefault(n => n.ID == ID);
                return nastavnoOsoblje;
            }
        }

        //public void azurirajNastavnoOsoblje(int ID)
        //{

        //}

        public void obrisiNastavnoOsoblje(int ID)
        {
            NastavnoOsoblje nastavnoOsoblje = preuzmiNastavnoOsoblje(ID);
            if(nastavnoOsoblje == null)
            {
                throw new Exception("Nastavno osoblje sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.NastavnoOsoblje.Remove(nastavnoOsoblje);
                context.SaveChanges();
            }

        }

    }
}
