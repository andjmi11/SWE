using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Immutable;

namespace Elfind.Data.Services
{
    public class KursService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public KursService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajKursAsync(Kurs kurs)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Kursevi.Add(kurs);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Kurs> PreuzmiKursAsync(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Kurs kurs = await context.Kursevi
                        .Include(x=>x.Studenti)
                        .Include(x=>x.Casovi)
                       .Include(x=>x.Smerovi)
                       .Include(x=>x.NastavnoOsoblje)
                       .SingleOrDefaultAsync(k => k.ID == ID);
                    return kurs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }
        public async Task<Kurs> PreuzmiKursPoNazivuAsync(string naziv)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Kurs kurs = await context.Kursevi
                         .Include(x => x.Studenti).ThenInclude(x=>x.Student)
                        .Include(x => x.Casovi).ThenInclude(x=>x.Prostorija)
                       .Include(x => x.Smerovi).ThenInclude(x=>x.Smer)
                       .Include(x => x.NastavnoOsoblje).ThenInclude(x=>x.NastavnoOsoblje)
                        .SingleOrDefaultAsync(k => k.Naziv == naziv);

                    //List<Cas> casovi = await context.Casovi
                    //    .Include(x=>x.ZaKurs)
                    //    .Include(x=>x.URasporeduCasova)
                    //    .Where(x => x.ZaKurs.ID == kurs.ID).ToListAsync();


                   /* List<KursSmer> smerovi = await context.KursSmerSpoj
                        .Include(x=>x.Kurs)
                        .Include(x=>x.Smer)
                        .Where(x => x.Kurs.ID == kurs.ID).ToListAsync();*/


                    
                    //List<OsobljeKurs> osoblje = await context.OsobljeKursSpoj
                    //    .Include(x=>x.Kurs)
                    //    .Include(x=>x.NastavnoOsoblje)
                    //    .Where(x => x.Kurs.ID == kurs.ID).ToListAsync();
                    //List<StudentKurs> studenti = await context.StudentKursSpoj
                    //    .Include(x=>x.Kurs)
                    //    .Include(x=>x.Student)
                    //    .Where(x=>x.Kurs.ID==kurs.ID).ToListAsync();

                    //kurs.Casovi.AddRange(casovi);
                   // kurs.Smerovi.AddRange(smerovi);
                    //kurs.NastavnoOsoblje.AddRange(osoblje);
                    //kurs.Studenti.AddRange(studenti);

                    return kurs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public async Task AzurirajKursAsync(int ID, string Naziv, int Godina)
        {
            try
            {
                Kurs kurs = await PreuzmiKursAsync(ID);
                if (kurs == null)
                {
                    throw new Exception("Kurs sa datim ID-jem ne postoji!");
                }
                kurs.Naziv = Naziv;
                kurs.Godina = Godina;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(kurs);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiKursAsync(int ID)
        {
            try
            {
                Kurs kurs = await PreuzmiKursAsync(ID);
                if (kurs == null)
                {
                    throw new Exception("Kurs sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(kurs);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Kurs>> VratiSveKurseveAsync()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Kurs> kursevi = await context.Kursevi
                         .Include(x => x.Studenti)
                        .Include(x => x.Casovi)
                       .Include(x => x.Smerovi).ThenInclude(x => x.Smer)
                       .Include(x => x.NastavnoOsoblje).ToListAsync();
                    return kursevi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Kurs>(); 
            }
        }

        public async Task<List<Kurs>> VratiKurseveZaKalendar()
        {
            try
            {
                using(var context = dbContextFactory.CreateDbContext())
                {
                    //prvo cu da vraitm sve casove da bih ih upisala u liste u kursevima, ukoliko vec posotje obrisi samo ovu liniju
                    List<Cas> casovi = await context.Casovi.Include(x=>x.Prostorija).Where(x => x.URasporeduCasova == null).ToListAsync();

                    KursService kService = new KursService(dbContextFactory);
                    List<Kurs> kursevi = await kService.VratiSveKurseveAsync();

                    //ovde ce sada svi kursevi imati svoju listu kurseva
                    foreach(var k in kursevi)
                    {
                        foreach(var c in casovi)
                        {
                            if(c.ZaKurs.ID == k.ID)
                            {
                                k.Casovi.Add(c);
                            }
                        }
                    }

                    return kursevi;//ovo bi trebalo da vrati sve kurseve cije su liste pune samo casovima koji nisu u rasporedu

                    
                }
            }
            catch(Exception e)
            {
                //greska
                return new List<Kurs>();
            }
        }

        /*public async Task<List<Kurs>> VratiSveKurseveZaTipStudijaAsync()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Kurs> kursevi = await context.Kursevi
                         .Include(x => x.Studenti)
                        .Include(x => x.Casovi)
                       .Include(x => x.Smerovi)
                       .Include(x => x.NastavnoOsoblje)                       
                       .ToListAsync();
                    return kursevi;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Kurs>();
            }
        }*/

        public async Task<List<Kurs>> VratiKurseveNastavnogOsoblja(string korisnickoIme)
        {
            NastavnoOsobljeService nService = new NastavnoOsobljeService(dbContextFactory);
            NastavnoOsoblje nastavnoOsoblje = await nService.PreuzmiNastavnoOsobljePoKorisnickomImenuAsync(korisnickoIme);

            try
            {



                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Kurs> kursevi = await context.Kursevi.ToListAsync();

                    List<OsobljeKurs> osobljeKurs = await context.OsobljeKursSpoj
                        .Where(x => x.NastavnoOsoblje.KorisnickoIme == nastavnoOsoblje.KorisnickoIme)
                        .Include(x => x.Kurs)
                        .Include(x => x.NastavnoOsoblje)
                        .ToListAsync();

                    List<Kurs> kurseviNastavno = kursevi.Where(x => osobljeKurs.Any(p => p.Kurs.ID == x.ID)).ToList();

                    return kurseviNastavno;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Kurs>();
            }
        }

        public async Task<List<Kurs>> VratiKurseveNaSmeru(string smer)//andjelija
        {
            SmerService SService = new SmerService(dbContextFactory);
            Smer s = await SService.PreuzmiSmerPoNazivu(smer);
            try
            { 
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Kurs> kursevi = await context.Kursevi.ToListAsync();

                    List<KursSmer> kursSmer = await context.KursSmerSpoj
                        .Where(x=>x.Smer.Naziv == s.Naziv)
                        .Include(x => x.Smer)
                        .Include(x => x.Kurs)
                        .ToListAsync();

                    List<Kurs> kurseviSmer = kursevi.Where(x => kursSmer.Any(p => p.Kurs.ID == x.ID)).ToList();

                    return kurseviSmer;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Kurs>();
            }
        }

        public async Task<List<Kurs>> VratiKursevePoNazivu(string kurs)//andjelija
        {
           
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Kurs> kursevi = await context.Kursevi.ToListAsync();

                    List<KursSmer> kursSmer = await context.KursSmerSpoj
                        .Where(x => x.Kurs.Naziv == kurs)
                        .Include(x => x.Smer)
                        .Include(x => x.Kurs)
                        .ToListAsync();

                    List<Kurs> kurseviSmer = kursevi.Where(x => kursSmer.Any(p => p.Kurs.ID == x.ID)).ToList();

                    return kurseviSmer;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Kurs>();
            }
        }


    }
}
