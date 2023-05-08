using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class OpcijaService
    {
       /* private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public OpcijaService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajOpciju(Opcija opcija)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Opcija.Add(opcija);
                context.SaveChanges();
            }
        }

        public Opcija preuzmiOpciju(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Opcija opcija = context.Opcija.SingleOrDefault(o => o.ID == ID);
                return opcija;
            }
        }

        *//*public void azurirajObjavu(int ID)
        {

        }*//*

        public void obrisiObjavu(int ID)
        {
            Objava objava = preuzmiObjavu(ID);
            if (objava == null)
            {
                throw new Exception("Notifikacija sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(objava);
                context.SaveChanges();
            }
        }*/
    }
}
