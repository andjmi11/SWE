using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class AdministratorService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;
        public AdministratorService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task dodajAdministratora(Administrator administrator)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Administratori.Add(administrator);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Administrator> preuzmiAdministratora(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Administrator administrator = await context.Administratori
                        .Include(x=>x.RasporediCasova)
                        .SingleOrDefaultAsync(a => a.ID == ID);
                    return administrator;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public async Task azurirajAdministratora(int ID, string ime, string prezime, string korisnickoIme)
        {
            try
            {
                Administrator administrator = await preuzmiAdministratora(ID);
                if (administrator == null)
                {
                    throw new Exception("Administrator sa datim ID-jem ne postoji!");
                }
                administrator.Ime = ime;
                administrator.Prezime = prezime;
                administrator.KorisnickoIme = korisnickoIme;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(administrator);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task obrisiAdministratora(int ID)
        {
            try
            {
                Administrator administrator = await preuzmiAdministratora(ID);
                if (administrator == null)
                {
                    throw new Exception("Administrator sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(administrator);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Administrator>> VratiSveAdministratore()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Administrator> administratori = await context
                        .Administratori
                        .Include(x=>x.RasporediCasova)
                        .ToListAsync();
                    return administratori;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Administrator>();
            }
        }

        public async Task<Administrator> PreuzmiAdministratoraPoKorisnickomImenu(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Administrator a = await context.Administratori.FirstAsync(x => x.KorisnickoIme == korisnickoIme);

                    return a;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
