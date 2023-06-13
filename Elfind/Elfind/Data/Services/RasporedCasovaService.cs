using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class RasporedCasovaService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public RasporedCasovaService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajRasporedCasova(RasporedCasova rasporedCasova)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    rasporedCasova.ZaSmer = context.Smerovi.SingleOrDefault(r => r.ID == rasporedCasova.ZaSmer.ID);
                    rasporedCasova.Administrator = context.Administratori.SingleOrDefault(r => r.ID == rasporedCasova.Administrator.ID);
                    context.ResporediCasova.Add(rasporedCasova);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<RasporedCasova> PreuzmiRasporedCasova(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    RasporedCasova rasporedCasova = await context.ResporediCasova.SingleOrDefaultAsync(r => r.ID == ID);
                    return rasporedCasova;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajRasporedCasova(int ID, Smer zaSmer, Administrator administrator)
        {
            try
            {
                RasporedCasova rasporedCasova = await PreuzmiRasporedCasova(ID);
                if (rasporedCasova == null)
                {
                    throw new Exception("Raspored casova sa datim ID-jem ne postoji!");
                }
                rasporedCasova.ZaSmer = zaSmer;
                rasporedCasova.Administrator = administrator;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(rasporedCasova);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiRasporedCasova(int ID)
        {
            try
            {
                RasporedCasova rasporedCasova = await PreuzmiRasporedCasova(ID);
                if (rasporedCasova == null)
                {
                    throw new Exception("Raspored casova sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(rasporedCasova);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<RasporedCasova>> VratiSveRasporedeCasova()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<RasporedCasova> rasporediCasova = await context.ResporediCasova
                        .Include(r=>r.ZaSmer)
                        .Include(r=>r.Administrator)
                        .ToListAsync();
                    return rasporediCasova;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<RasporedCasova>();
            }
        }

    }
}
