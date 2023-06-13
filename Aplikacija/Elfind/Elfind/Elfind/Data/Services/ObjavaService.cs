using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elfind.Data.Services
{
    public class ObjavaService
    {
        private readonly IDbContextFactory<ElfindContext> dbContextFactory;

        public ObjavaService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Objava> DodajObjavu(Objava objava)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    objava.OdNastavnogOsoblja = await context.NastavnoOsoblje.SingleOrDefaultAsync(n => n.ID == objava.OdNastavnogOsoblja.ID);
                    objava.Forum = await context.Forum.SingleOrDefaultAsync(f => f.ID == objava.Forum.ID);

                    context.Objave.Add(objava);
                    await context.SaveChangesAsync();
                }
                return objava;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Objava> PreuzmiObjavu(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Objava objava = await context.Objave.Include(o => o.OdNastavnogOsoblja)
                        .Include(o => o.Forum).Include(x => x.Opcije).SingleOrDefaultAsync(o => o.ID == ID);
                    return objava;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task ObrisiObjavu(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Objava objava = await context.Objave.Include(o => o.Forum).FirstOrDefaultAsync(o => o.ID == ID);
                    if (objava == null)
                    {
                        throw new Exception("Objava sa datim ID-jem ne postoji!");
                    }

                    // Primer: Brisanje veza ObjavaStudent
                    List<ObjavaStudent> vezeObjavaStudent = await context.ObjavaStudent.Where(os => os.Objava.ID == objava.ID).ToListAsync();
                    context.ObjavaStudent.RemoveRange(vezeObjavaStudent);

                    // Primer: Brisanje objava iz liste objava u forumu
                    objava.Forum.Objave.Remove(objava);

                    // Primer: Brisanje objava iz referenci u NastavnoOsoblje
                    foreach (var nastavnoOsoblje in context.NastavnoOsoblje)
                    {
                        var objavaOsoblja = nastavnoOsoblje.Objave.FirstOrDefault(o => o.ID == objava.ID);
                        if (objavaOsoblja != null)
                        {
                            nastavnoOsoblje.Objave.Remove(objavaOsoblja);
                        }
                    }



                    // Primer: Brisanje objava iz referenci u opcijama
                    List<Opcija> opcije = await context.Opcije.Where(o => o.Anketa.ID == objava.ID).ToListAsync();
                    context.Opcije.RemoveRange(opcije);

                    // Primer: Brisanje objava iz liste objava studenta
                    foreach (var student in context.Studenti)
                    {
                        var objavaStudent = student.Objave.FirstOrDefault(os => os.Objava.ID == objava.ID);
                        if (objavaStudent != null)
                        {
                            student.Objave.Remove(objavaStudent);
                        }

                    }
                    context.Remove(objava);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Objava>> VratiSveObjave()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Objava> objave = await context.Objave
                        .Include(o => o.OdNastavnogOsoblja)
                        .Include(o => o.Forum)
                        .Include(x => x.Opcije)
                        .ToListAsync();
                    return objave;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<Objava>> VratiSveObjaveZaNastavnoOsoblje(int nID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Objava> objave = await context.Objave
                        .Where(x => x.OdNastavnogOsoblja.ID == nID)
                        .Include(o => o.OdNastavnogOsoblja)
                        .Include(o => o.Forum)
                        .Include(x => x.Opcije)
                        .ToListAsync();
                    return objave;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<Objava>> VratiSveObjaveZaSmer(string smer)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    //StudentService sService = new StudentService(dbContextFactory);
                    //Student student = await sService.PreuzmiStudentaPoKorisnickomImenu(korisnickoIme);

                    List<ObjavaStudent> objs = await context.ObjavaStudent
                        .Where(x => x.Student.NaSmeru.Naziv == smer)
                        .Include(x => x.Objava).ThenInclude(c => c.OdNastavnogOsoblja)
                        .Include(x => x.Objava).ThenInclude(x => x.Opcije)
                        .Include(o => o.Student).ThenInclude(x => x.NaSmeru)
                        .ToListAsync();

                    List<Objava> obj = await context.Objave.ToListAsync();

                    List<Objava> objave = obj
                        .Where(p => objs.Any(l => l.Objava.ID == p.ID))
                        .ToList();

                    return objave;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Objava>();
            }
        }




    }
}
