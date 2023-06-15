using Elfind.Data.Model;
using Elfind.Data.Models;
using Elfind.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Elfind.Data.Services
{
    public class NastavnoOsobljeService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public NastavnoOsobljeService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajNastavnoOsobljeAsync(NastavnoOsoblje nastavnoOsoblje)
        {
            try
            {
                var nastavnikPostoji = await PreuzmiNastavnoOsobljePoKorisnickomImenuAsync(nastavnoOsoblje.KorisnickoIme);
                if (nastavnikPostoji == null)
                {
                    using (var context = dbContextFactory.CreateDbContext())
                    {
                        nastavnoOsoblje.Kancelarija = await context.Prostorije.SingleOrDefaultAsync(n => n.ID == nastavnoOsoblje.Kancelarija.ID);
                        context.NastavnoOsoblje.Add(nastavnoOsoblje);
                        await context.SaveChangesAsync();
                    }
                }
                else
                {
                    Console.WriteLine("Nastavno osoblje sa tim korisnickim imenom vec postoji!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<NastavnoOsoblje> PreuzmiNastavnoOsobljeAsync(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NastavnoOsoblje nastavnoOsoblje = await context.NastavnoOsoblje.AsNoTracking()
                        .Include(n => n.Kancelarija)
                        .Include(x=>x.Objave)
                        .Include(x=>x.Kursevi)
                        .Include(x=>x.RezProstorije)
                        .Include(x=>x.Raspored)
                        .FirstOrDefaultAsync(n => n.ID == ID);
                    return nastavnoOsoblje;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<NastavnoOsoblje> PreuzmiNastavnoOsobljePoKorisnickomImenuAsync(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NastavnoOsoblje n = await context.NastavnoOsoblje.AsNoTracking()
                        .Include(n => n.Kancelarija)
                        .FirstAsync(x => x.KorisnickoIme == korisnickoIme);
                                       

                    List<Data.Model.Objava> objave = await context.Objave
                        .Include(x=>x.OdNastavnogOsoblja)
                        .Where(x => x.OdNastavnogOsoblja.ID == n.ID).ToListAsync();

                    //falice za sad notifikacije dok izmislime
                    List<OsobljeKurs> kursevi = await context.OsobljeKursSpoj
                        .Include(x=>x.Kurs).ThenInclude(x => x.Casovi)
                        .Include(x=>x.NastavnoOsoblje)
                        .Where(x=>x.NastavnoOsoblje.ID==n.ID).ToListAsync();
                    List<OsobljeProstorijaR> rezProstorije = await context.OsobljeProstorijaRSpoj
                        .Include(x=>x.Prostorija)
                        .Include(x=>x.NastavnoOsoblje)
                        .Where(x => x.NastavnoOsoblje.ID == n.ID).ToListAsync();
                    List<OsobljeRaspored> rasporedi = await context.OsobljeRasporedSpoj
                        .Include(x=>x.NastavnoOsoblje)
                        .Include(x=>x.RasporedCasova)
                        .Where(x=>x.NastavnoOsoblje.ID != n.ID).ToListAsync();

                    n.Objave.AddRange(objave);
                    n.Kursevi.AddRange(kursevi);
                    n.RezProstorije.AddRange(rezProstorije);
                    n.Raspored.AddRange(rasporedi);

                    return n;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
        public async Task<NastavnoOsoblje> PreuzmiNastavnoOsobljePoKIKratkaAsync(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    NastavnoOsoblje n = await context.NastavnoOsoblje.AsNoTracking()
                        .Include(n => n.Kancelarija)
                        .Include(x => x.Objave) //andj dodaces sta ti treba
                        .Include(x => x.Kursevi).ThenInclude(x => x.Kurs).ThenInclude(x=> x.Casovi).ThenInclude(x=> x.Prostorija)
                        .Include(x => x.Kursevi).ThenInclude(x => x.Kurs).ThenInclude(x=> x.Casovi).ThenInclude(x=> x.URasporeduCasova)
                        .Include(x => x.Kursevi).ThenInclude(x => x.Kurs).ThenInclude(x=> x.Smerovi).ThenInclude(x => x.Smer)
                        .Include(x => x.RezProstorije).ThenInclude(x => x.Prostorija)
                        .Include(x=> x.Raspored).ThenInclude(x => x.RasporedCasova).ThenInclude(x=> x.SpisakCasova)
                        .Include(x=> x.Raspored).ThenInclude(x => x.RasporedCasova).ThenInclude(x=> x.ZaSmer)
                        .FirstAsync(x => x.KorisnickoIme == korisnickoIme);


                    return n;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<NastavnoOsoblje> PreuzmiNastavnoOsobljePoImenuAsync(string ime)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    if (ime.Contains(' ')) //ime i prezime i sada je samo to moguce
                    {
                        string[] delovi = ime.Split(' ');
                        NastavnoOsoblje n = await context.NastavnoOsoblje.AsNoTracking()
                        .Include(n => n.Kancelarija)
                        .Include(x => x.Objave)
                        .Include(x => x.Kursevi)
                        .Include(x => x.RezProstorije)
                        .Include(x => x.Raspored)
                            .FirstAsync(x => x.Ime == delovi[0] && x.Prezime == delovi[1]);
                        return n;
                    }
                    else //samo ime
                    {
                        //NastavnoOsoblje n = await context.NastavnoOsoblje.AsNoTracking().Include(n => n.Kancelarija).Include(x => x.Objave).Include(x => x.Kursevi).Include(x => x.RezProstorije).Include(x => x.Raspored).FirstAsync(x => x.Ime == ime);
                        //n ??= await context.NastavnoOsoblje.AsNoTracking().Include(n => n.Kancelarija).FirstAsync(x => x.Prezime == ime);
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<NastavnoOsoblje>> PreuzmiNastavnoOsobljePoImenuListaAsync(string ime)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    if (ime.Contains(' ')) //ime i prezime i sada je samo to moguce
                    {
                        string[] delovi = ime.Split(' ');
                        List<NastavnoOsoblje> nastavnoOsobljeList = await context.NastavnoOsoblje.AsNoTracking()
                            .Include(n => n.Kancelarija)
                            .Include(x => x.Objave)
                            .Include(x => x.Kursevi)
                            .Include(x => x.RezProstorije)
                            .Include(x => x.Raspored)
                            .Where(x => x.Ime == delovi[0] && x.Prezime == delovi[1])
                            .ToListAsync();

                        return nastavnoOsobljeList;
                    }
                    else //samo ime
                    {
                        List<NastavnoOsoblje> nastavnoOsobljeList = await context.NastavnoOsoblje.AsNoTracking()
                            .Include(n => n.Kancelarija)
                            .Where(x => x.Ime == ime)
                            .ToListAsync();

                        return nastavnoOsobljeList;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task AzurirajNastavnoOsobljeAsync(NastavnoOsoblje n)
        {
            try
            {              
                using (var context = dbContextFactory.CreateDbContext())
                {
                    //context.Entry(nastavnoOsoblje).State = EntityState.Detached;

                    context.NastavnoOsoblje.Update(n);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiNastavnoOsobljeAsync(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NastavnoOsoblje nastavnoOsoblje = await context.NastavnoOsoblje.SingleOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);
                    if (nastavnoOsoblje == null)
                    {
                        throw new Exception("Nastavno osoblje sa datim ID-jem ne postoji!");
                    }

                    List<Data.Model.Objava> objave = await context.Objave.Where(x => x.OdNastavnogOsoblja.KorisnickoIme == korisnickoIme).ToListAsync();
                    foreach(var obj in objave)
                    {
                        List<ObjavaStudent> objSt = await context.ObjavaStudent.Where(x => x.Objava.ID == obj.ID).ToListAsync();
                        foreach(var os in objSt)
                        {
                            context.ObjavaStudent.Remove(os);
                        }
                        List<Opcija> opc = await context.Opcije.Where(x => x.Anketa.ID == obj.ID).ToListAsync();
                        foreach(var o in opc)
                        {
                            context.Opcije.Remove(o);
                        }
                        context.Objave.Remove(obj);
                    }
                    List<OsobljeRaspored> osobljeRasp = await context.OsobljeRasporedSpoj.Where(os => os.NastavnoOsoblje.KorisnickoIme == korisnickoIme).ToListAsync();
                    context.OsobljeRasporedSpoj.RemoveRange(osobljeRasp);

                    List<OsobljeProstorijaR> osobljePros = await context.OsobljeProstorijaRSpoj.Where(n => n.NastavnoOsoblje.KorisnickoIme == korisnickoIme).ToListAsync();
                    context.OsobljeProstorijaRSpoj.RemoveRange(osobljePros);

                    List<OsobljeKurs> osobljeKurs = await context.OsobljeKursSpoj.Where(x => x.NastavnoOsoblje.KorisnickoIme == korisnickoIme).ToListAsync();
                    context.OsobljeKursSpoj.RemoveRange(osobljeKurs);

                    

                    foreach (var p in context.Prostorije)
                    {
                        var pr = p.NastavnoOsobljeUKancelariji.FirstOrDefault(o => o.KorisnickoIme==korisnickoIme);
                        if (pr != null)
                        {
                            p.NastavnoOsobljeUKancelariji.Remove(pr);
                        }
                    }



                    context.NastavnoOsoblje.Remove(nastavnoOsoblje);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<NastavnoOsoblje>> VratiSveNastavnikeAsync()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<NastavnoOsoblje> nastavnoOsoblje = await context.NastavnoOsoblje
                        .Include(n => n.Kancelarija)
                        .Include(x=>x.Objave)
                        .Include(x=>x.RezProstorije).ThenInclude(x=>x.Prostorija)
                        .Include(x=>x.Raspored)
                        .ToListAsync();
                    return nastavnoOsoblje;
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
