using Elfind.Data.Model;
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
                    student.NaSmeru = context.Smerovi.SingleOrDefault(s=>s.ID==student.NaSmeru.ID);
                    student.RasporedCasova = context.ResporediCasova.SingleOrDefault(s => s.ID == student.RasporedCasova.ID);
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
                    Student student = await context.Studenti.FirstOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);
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
                    Student student = await context.Studenti.FirstOrDefaultAsync(x => x.ID == ID);
                    return student;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajStudenta(int ID, string ime, string prezime, string korisnickoIme)
        {
            try
            {
                Student student = await PreuzmiStudenta(ID);
                if (student == null)
                {
                    throw new Exception("Student sa datim ID-jem ne postoji!");
                }
                student.Ime = ime;
                student.Prezime = prezime;
                student.KorisnickoIme = korisnickoIme;
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Update(student);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ObrisiStudenta(int ID)
        {
            try
            {
                Student student = await PreuzmiStudenta(ID);
                if (student == null)
                {
                    throw new Exception("Student sa datim ID-jem ne postoji!");
                }
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Remove(student);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Student>> VratiSveStudente()
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    List<Student> studenti = await context.Studenti
                        .Include(s => s.NaSmeru)
                        .Include(s => s.RasporedCasova)
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


    }

}
