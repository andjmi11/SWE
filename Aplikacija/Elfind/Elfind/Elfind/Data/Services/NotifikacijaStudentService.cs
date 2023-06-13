using Elfind.Data.Models;
using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data.Services
{
    public class NotifikacijaStudentService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public NotifikacijaStudentService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task DodajNotifikacijaStudent(NotifikacijaStudent nt)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    
                    nt.Student = await context.Studenti.SingleOrDefaultAsync(n => n.ID == nt.Student.ID);
                    nt.Notifikacija = await context.Notifications.SingleOrDefaultAsync(n => n.MsgID == nt.Notifikacija.MsgID);

                    StudentService sService = new StudentService(dbContextFactory);
                    Student student = await sService.PreuzmiStudenta(nt.Student.ID);

                    NotificationMessageService nService = new NotificationMessageService(dbContextFactory);
                    NotificationMessage notif = await nService.PreuzmiNotifikaciju(nt.Notifikacija.MsgID);

                    student.Notifikacije.Add(nt);
                    notif.Primaoci.Add(nt);

                    context.NotifikacijaStudent.Add(nt);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task SetPorukaVidjena(int msgId)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    var notifikacijaStudenti = await context.NotifikacijaStudent
                        .Where(x => x.Notifikacija.MsgID == msgId && !x.VidjenaPoruka)
                        .ToListAsync();

                    foreach (var notifikacijaStudent in notifikacijaStudenti)
                    {
                        notifikacijaStudent.VidjenaPoruka = true;
                    }

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
