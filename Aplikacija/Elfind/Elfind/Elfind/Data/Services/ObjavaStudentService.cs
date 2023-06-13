using Elfind.Data.Models;
using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class ObjavaStudentService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public ObjavaStudentService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajObjavaStudent(ObjavaStudent ob)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    ob.Student = await context.Studenti.SingleOrDefaultAsync(x=>x.ID == ob.Student.ID);
                    ob.Objava = await context.Objave.SingleOrDefaultAsync(x=>x.ID==ob.Objava.ID);

                    StudentService sService = new StudentService(dbContextFactory);
                    Student student = await sService.PreuzmiStudenta(ob.Student.ID);

                    ObjavaService oService = new ObjavaService(dbContextFactory);
                    Objava objava = await oService.PreuzmiObjavu(ob.Objava.ID);

                    student.Objave.Add(ob);
                    objava.Studenti.Add(ob);
                            

                    context.ObjavaStudent.Add(ob);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
