using Elfind.Data.Model;
using Elfind.Data.Models;
using Elfind.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Elfind.Data.Services
{
    public class StudentService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public StudentService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajStudenta(Student student)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    student.NaSmeru = await context.Smerovi.SingleOrDefaultAsync(s => s.ID == student.NaSmeru.ID);
                    student.RasporedCasova = await context.ResporediCasova.SingleOrDefaultAsync(s => s.ID == student.RasporedCasova.ID);
                    context.Studenti.Add(student);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Student> PreuzmiStudentaPoKorisnickomImenu(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Student student = await context.Studenti.Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova)
                        .Include(x=>x.Kursevi)
                        .FirstOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);

                    List<StudentKurs> kursevi = await context.StudentKursSpoj
                        .Include(x => x.Kurs)
                        .Include(x => x.Student)
                        .Where(x => x.Student.ID == student.ID).ToListAsync();

                    student.Kursevi.AddRange(kursevi);

                    return student;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
        public async Task<Student> PreuzmiStudentaPoKorisnickomImenuKratka(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Student student = await context.Studenti.Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova)
                        .Include(x=>x.Kursevi).ThenInclude(x => x.Kurs).ThenInclude(x => x.Casovi).ThenInclude(x => x.Prostorija) //pa valjda je dosta
                        .FirstOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);

                    return student;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Student> PreuzmiStudenta(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Student student = await context.Studenti.AsNoTracking().Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova).Include(x=>x.Kursevi).FirstOrDefaultAsync(x => x.ID == ID);
                    return student;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajStudenta(Student s)
        {
            try
            {
                Student student = await PreuzmiStudenta(s.ID);
                if (student == null)
                {
                    throw new Exception("Student sa datim ID-jem ne postoji!");
                }
                student.Ime = s.Ime;
                student.Prezime = s.Prezime;
                student.KorisnickoIme = s.KorisnickoIme;
                student.NaSmeru = s.NaSmeru;
                student.Godina = s.Godina;
                student.TipStudija = s.TipStudija;

                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Attach(student.NaSmeru);

                    context.Update(student);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiStudenta(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Student student = await context.Studenti.FirstOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);
                    if (student == null)
                    {
                        throw new Exception("Student sa datim ID-jem ne postoji!");
                    }
                    List<ObjavaStudent> vezeObjavaStudent = await context.ObjavaStudent.Where(os => os.Student.KorisnickoIme == korisnickoIme).ToListAsync();
                    context.ObjavaStudent.RemoveRange(vezeObjavaStudent);

                    List<StudentKurs> vezeStudentKurs = await context.StudentKursSpoj.Where(os => os.Student.KorisnickoIme == korisnickoIme).ToListAsync();
                    context.StudentKursSpoj.RemoveRange(vezeStudentKurs);

                    List<NotifikacijaStudent> vezeStudentNotifikacija = await context.NotifikacijaStudent.Where(os => os.Student.KorisnickoIme == korisnickoIme).ToListAsync();
                    context.NotifikacijaStudent.RemoveRange(vezeStudentNotifikacija);

                    context.Remove(student);




                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /* public async Task ObrisiObjavu(int ID)
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

                    // Primer: Brisanje notifikacija povezanih sa objavom
                    List<Notifikacija> notifikacije = await context.Notifikacije.Where(n => n.ZaObjavu.ID == objava.ID).ToListAsync();
                    context.Notifikacije.RemoveRange(notifikacije);


                    // Nakon što su svi povezani entiteti obrisani, možete ukloniti objavu iz konteksta i pozvati SaveChangesAsync da biste sačuvali promene i izvršili brisanje
                    context.Remove(objava);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/
        public async Task<List<Student>> VratiSveStudente()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Student> studenti = await context.Studenti
                        .Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova)
                        .Include(x=>x.Kursevi)
                        .ToListAsync();
                    return studenti;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Student>();
            }
        }
        public async Task<Student> PreuzmiStudentaPoIndeksu(int indeks)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Student student = await context.Studenti.Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova).FirstOrDefaultAsync(x => x.Indeks == indeks);
                    return student;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<Student>> VratiStudentePoSmeru(string smer)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Student> studenti = await context.Studenti
                           .Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova)
                        .Include(x => x.Kursevi)
                        .Where(x=>x.NaSmeru.Naziv == smer)
                        .ToListAsync();
                    return studenti;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Student>();
            }
        }
        public async Task<Student> PreuzmiStudentaPoSmeru(string smer)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    Student student = await context.Studenti.Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova).Include(x => x.Kursevi).FirstOrDefaultAsync(x => x.NaSmeru.Naziv == smer);
                    return student;
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

