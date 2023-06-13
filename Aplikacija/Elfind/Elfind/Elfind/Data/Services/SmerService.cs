using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class SmerService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public SmerService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajSmer(Smer smer)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Smerovi.Add(smer);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Smer> PreuzmiSmer(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Smer smer = await context.Smerovi.Include(x=>x.Kursevi).SingleOrDefaultAsync(s => s.ID == ID);

                    List<KursSmer> kursevi = await context.KursSmerSpoj
                        .Include(x => x.Kurs)
                        .Include(c => c.Smer)
                        .Where(x => x.Smer.ID == smer.ID).ToListAsync();

                    smer.Kursevi.AddRange(kursevi);
                    return smer;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajSmer(int ID, string naziv)
        {
            try
            {
                Smer smer = await PreuzmiSmer(ID);
                if (smer == null)
                {
                    throw new Exception("Smer sa datim ID-jem ne postoji!");
                }
                smer.Naziv = naziv;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(smer);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiSmer(int ID)
        {
            try
            {
                Smer smer = await PreuzmiSmer(ID);
                if (smer == null)
                {
                    throw new Exception("Smer sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(smer);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Smer>> VratiSveSmerove()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Smer> smerovi = await context.Smerovi.Include(x=>x.Kursevi).ThenInclude(x => x.Kurs).ToListAsync();
                    return smerovi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Smer>();
            }
        }

        public async Task<List<Smer>> VratiSveSmerovePoTipuStudija(string tipStudija)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    var tipStudijaEnum = Enum.Parse<TipStudija>(tipStudija);
                    List<Smer> smerovi = await context.Smerovi
                        .Where(x => x.TipStudija == tipStudijaEnum)
                        .Include(x => x.Kursevi)
                        .ToListAsync();

                    return smerovi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Smer>();
            }
        }
        public async Task<Smer> PreuzmiSmerPoNazivu(string naziv)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Smer smer = await context.Smerovi.Include(x => x.Kursevi).SingleOrDefaultAsync(s => s.Naziv == naziv);

                    List<KursSmer> kursevi = await context.KursSmerSpoj
                        .Include(x => x.Kurs)
                        .Include(c => c.Smer)
                        .Where(x => x.Smer.ID == smer.ID).ToListAsync();

                    smer.Kursevi.AddRange(kursevi);
                    return smer;
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
