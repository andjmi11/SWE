using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ObjavaService
    {
        //private IDbContextFactory<ElfindDbContext> dbContextFactory;

        //public ObjavaService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        //{
        //    this.dbContextFactory = dbContextFactory;
        //}

        //public void dodajObjavu(Objava objava)
        //{
        //    using (var context = dbContextFactory.CreateDbContext())
        //    {
        //        context.Objave.Add(objava);
        //        context.SaveChanges();
        //    }
        //}

        //public Objava preuzmiObjavu(int ID)
        //{
        //    using (var context = dbContextFactory.CreateDbContext())
        //    {
        //        Objava objava = context.Opcija.SingleOrDefault(o => o.ID == ID);
        //        return objava;
        //    }
        //}

        ///*public void azurirajObjavu(int ID)
        //{

        //}*/

        //public void obrisiObjavu(int ID)
        //{
        //    Objava objava = preuzmiObjavu(ID);
        //    if (objava == null)
        //    {
        //        throw new Exception("Notifikacija sa datim ID-jem ne postoji!");
        //    }
        //    using (var context = dbContextFactory.CreateDbContext())
        //    {
        //        context.Remove(objava);
        //        context.SaveChanges();
        //    }
        //}
    }
}
