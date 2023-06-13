using Elfind.Data.Model;
using Elfind.Pages;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class CasService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public CasService(IDbContextFactory<ElfindContext> dbContextFactory) 
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajCas(Cas cas)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    cas.Prostorija = context.Prostorije.SingleOrDefault(n => n.ID == cas.Prostorija.ID);
                    cas.URasporeduCasova = context.ResporediCasova.SingleOrDefault(n => n.ID == cas.URasporeduCasova.ID);
                    cas.ZaKurs = context.Kursevi.SingleOrDefault(n => n.ID == cas.ZaKurs.ID);

                    context.Casovi.Add(cas);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Cas> PreuzmiCas(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    Cas cas = await context.Casovi.SingleOrDefaultAsync(c => c.ID == ID);
                    return cas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajCas(int ID, string naziv, Dan dan, TimeSpan vremeOd, TimeSpan vremeDo, TipCasa tipCasa, Prostorija prostorija, RasporedCasova uRasporeduCasova, Kurs zaKurs)
        {
            try
            {
                Cas cas = await PreuzmiCas(ID);
                if (cas == null)
                {
                    throw new Exception("Cas sa datim ID-jem ne postoji!");
                }
                cas.ID = ID;
                cas.Naziv = naziv;
                cas.Dan = dan;
                cas.VremeOd = vremeOd;
                cas.VremeDo = vremeDo;
                cas.TipCasa = tipCasa;
                cas.Prostorija = prostorija;
                cas.URasporeduCasova = uRasporeduCasova;
                cas.ZaKurs = zaKurs;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(cas);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiCas(int ID)
        {
            try
            {
                Cas cas = await PreuzmiCas(ID);
                if (cas == null)
                {
                    throw new Exception("Cas sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(cas);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Cas>> VratiSveCasove()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Cas> casovi = await context.Casovi
                        .Include(c=>c.Prostorija)
                        .Include(c=>c.URasporeduCasova)
                        .Include(c=>c.ZaKurs)
                        .ToListAsync();
                    return casovi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Cas>(); 
            }
        }

    }
}
