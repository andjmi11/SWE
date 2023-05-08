using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class AdministratorService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;
        public AdministratorService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajAdministratora(Administrator administrator)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Administratori.Add(administrator);
                context.SaveChanges();
            }
        }

        public Administrator preuzmiAdministratora(int ID)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                Administrator administrator = context.Administratori.SingleOrDefault(a => a.ID == ID);
                return administrator;
            }
        }

        //azuriraj slicno kao za studenta kopiraj
        //public void azurirajAdministratora(int ID)
        //{

        //}

        public void obrisiAdministratora(int ID)
        {
            Administrator administrator = preuzmiAdministratora(ID);
            if(administrator == null)
            {
                throw new Exception("Administrator sa datim ID-jem ne postoji!");
            }
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(administrator);
                context.SaveChanges();
            }
        }
    }
}
