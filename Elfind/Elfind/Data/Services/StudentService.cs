using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Elfind.Data.Services
{
    public class StudentService
    {
        private IDbContextFactory<ElfindDbContext> dbContextFactory;

        public StudentService(IDbContextFactory<ElfindDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void dodajStudenta(Student student) 
        {
            using(var context = dbContextFactory.CreateDbContext())
            {
                context.Studenti.Add(student);
                context.SaveChanges();
            }
        }

        public Student preuzmiStudenta(int ID)
        {
            using(var context = dbContextFactory.CreateDbContext())
            {
                Student student  = context.Studenti.SingleOrDefault(x => x.ID == ID);
                return student;
            }
        }

        //public void azurirajStudenta(int ID, )

        public void obrisiStudenta(int ID)
        {
            Student student = preuzmiStudenta(ID);
            if(student == null)
            {
                throw new Exception("Student sa datim ID-jem ne postoji!");
            }
            using(var context = dbContextFactory.CreateDbContext())
            {
                context.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
