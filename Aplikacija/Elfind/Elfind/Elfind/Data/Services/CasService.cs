using Elfind.Data.Model;
using Elfind.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Elfind.Data.Services
{
    public class CasService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public CasService(IDbContextFactory<ElfindContext> dbContextFactory) 
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<int> DodajCas(Cas cas)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    cas.Prostorija =  await context.Prostorije.SingleOrDefaultAsync(n => n.ID == cas.Prostorija.ID);
                    cas.URasporeduCasova =  await context.ResporediCasova.SingleOrDefaultAsync(n => n.ID == cas.URasporeduCasova.ID); //NE ZNAM JEL BITNO 
                    cas.ZaKurs = await context.Kursevi.SingleOrDefaultAsync(n => n.ID == cas.ZaKurs.ID);
                    
                    //dodato
                    cas.ZaKurs.Casovi.Add(cas);
                    //cas.URasporeduCasova.SpisakCasova.a
                    cas.URasporeduCasova.SpisakCasova.Add(cas);

                    
                    context.Casovi.Add(cas);
                    await context.SaveChangesAsync();
                }
                return cas.ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public async Task<int> DodajCasBezRasporeda(Cas cas, NastavnoOsoblje osoba)
        {
            try
            {
                
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NastavnoOsoblje n = await context.NastavnoOsoblje.SingleOrDefaultAsync(x => x.ID == osoba.ID);
                    List<Student> studenti = await context.Studenti.ToListAsync();

                    cas.Prostorija =  await context.Prostorije.SingleOrDefaultAsync(n => n.ID == cas.Prostorija.ID);
                    cas.ZaKurs = await context.Kursevi.SingleOrDefaultAsync(n => n.ID == cas.ZaKurs.ID);
                    
                    foreach(var s in studenti)
                    {
                        foreach(var k in s.Kursevi)
                        {
                            if(k.ID == cas.ZaKurs.ID)
                            {
                                s.ListaZakazanihCasova.Add(cas);
                            }
                        }
                    }
                    //dodato
                    cas.ZaKurs.Casovi.Add(cas);
                    n.ListaZakazanihCasova.Add(cas);
                    context.Casovi.Add(cas);
                    await context.SaveChangesAsync();
                }
                return cas.ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public async Task<Cas> PreuzmiCas(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    Cas cas = await context.Casovi
                          .Include(c => c.Prostorija)
                        .Include(c => c.URasporeduCasova)
                        .Include(c => c.ZaKurs)
                        .SingleOrDefaultAsync(c => c.ID == ID);
                    return cas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Cas> PreuzmiCasPrilagodjena(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    Cas cas = await context.Casovi
                          //.Include(c => c.Prostorija).ThenInclude(x => x.NastavnoOsobljeR).ThenInclude(x=> x.Prostorija)
                          //.Include(c => c.Prostorija).ThenInclude(x => x.NastavnoOsobljeR).ThenInclude(x=> x.NastavnoOsoblje)
                          .Include(c=> c.Prostorija).ThenInclude( x => x.NastavnoOsobljeR).ThenInclude(x=> x.NastavnoOsoblje)
                         // .Include(c=> c.Zakazao).ThenInclude(x=>x.RezProstorije).ThenInclude(x=> x.Prostorija) //dodato obrnuto
                        .Include(c => c.URasporeduCasova)
                        .Include(c => c.ZaKurs)
                        .SingleOrDefaultAsync(c => c.ID == ID);
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

        public async Task<int> ObrisiCas(int ID)
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
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
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
                        .Include(c=>c.URasporeduCasova).ThenInclude(x => x.ZaSmer)
                        .Include(c=>c.ZaKurs).ThenInclude(x => x.NastavnoOsoblje).ThenInclude(x=>x.NastavnoOsoblje).ThenInclude(x=>x.RezProstorije)
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
