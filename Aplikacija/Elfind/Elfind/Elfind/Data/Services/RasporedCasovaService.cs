using Elfind.Data.Model;
using Elfind.Data.Models;
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
                    rasporedCasova.ZaSmer = await context.Smerovi.SingleOrDefaultAsync(r => r.ID == rasporedCasova.ZaSmer.ID);
                    rasporedCasova.Administrator = await context.Administratori.SingleOrDefaultAsync(r => r.ID == rasporedCasova.Administrator.ID);
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
                    RasporedCasova rasporedCasova = await context.ResporediCasova.Include(r => r.ZaSmer)
                        .Include(r => r.Administrator)
                        .Include(x=>x.SpisakCasova)
                        .Include(x=>x.NastavnoOsoblje).SingleOrDefaultAsync(r => r.ID == ID);
                    return rasporedCasova;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<RasporedCasova> PreuzmiRasporedCasovaPoSmeru(Smer smer)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    RasporedCasova rasporedCasova = await context.ResporediCasova.Include(r => r.ZaSmer)
                        .Include(r => r.Administrator).Include(x => x.SpisakCasova)
                        .Include(x => x.NastavnoOsoblje).SingleOrDefaultAsync(r => r.ZaSmer.ID == smer.ID);

                    List<OsobljeRaspored> osoblje = await context.OsobljeRasporedSpoj
                        .Include(x => x.RasporedCasova)
                        .Include(x => x.NastavnoOsoblje)
                        .Where(x => x.RasporedCasova.ID == rasporedCasova.ID).ToListAsync();

                    List<Cas> casovi = await context.Casovi.Include(x => x.URasporeduCasova)
                        .Include(x => x.ZaKurs)
                        .Where(x => x.URasporeduCasova.ID == rasporedCasova.ID).ToListAsync();

                    rasporedCasova.NastavnoOsoblje.AddRange(osoblje);
                    rasporedCasova.SpisakCasova.AddRange(casovi);

                    return rasporedCasova;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<RasporedCasova> PreuzmiRasporedCasovaPoSmeruKratka(Smer smer)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    RasporedCasova rasporedCasova = await context.ResporediCasova.Include(r => r.ZaSmer)
                        .Include(r => r.Administrator)
                        .Include(x => x.SpisakCasova)
                        .Include(x => x.NastavnoOsoblje).ThenInclude(x => x.NastavnoOsoblje)
                        .SingleOrDefaultAsync(r => r.ZaSmer.ID == smer.ID);

                

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

        public async Task ObrisiRasporedCasova(int smerID, int godina)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    RasporedCasova rasporedCasova = await context.ResporediCasova.SingleOrDefaultAsync(x => x.ZaSmer.ID == smerID && x.ZaGodinu == godina);
                    if (rasporedCasova == null)
                    {
                        throw new Exception("Raspored casova sa datim ID-jem ne postoji!");
                    }

                    List<Student> studenti = await context.Studenti.Where(o => o.RasporedCasova.ID == rasporedCasova.ID).ToListAsync();
                    context.Studenti.RemoveRange(studenti);

                    List<Cas> casovi = await context.Casovi.Where(x => x.URasporeduCasova.ID == rasporedCasova.ID).ToListAsync();
                    context.Casovi.RemoveRange(casovi);

                    foreach(var a in context.Administratori){
                        var adm = a.RasporediCasova.FirstOrDefault(x => x.ID == rasporedCasova.ID);
                        if(adm != null)
                        {
                            a.RasporediCasova.Remove(adm);
                        }
                    }

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
                        .Include(x => x.SpisakCasova)
                        .Include(x => x.NastavnoOsoblje)
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
