using Elfind.Data.Model;
using Elfind.Data.Models;
using Elfind.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data
{
    public class NotificationMessageService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public NotificationMessageService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task SaveNotification(NotificationMessage notification)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.Notifications.Add(notification);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task<List<NotificationMessage>> VratiProcitanePoruke(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    StudentService sService = new StudentService(dbContextFactory);
                    Student student = await sService.PreuzmiStudentaPoKorisnickomImenu(korisnickoIme);

                    List<NotifikacijaStudent> lista = await context.NotifikacijaStudent
                        .Where(x => x.VidjenaPoruka == true && x.Student.ID == student.ID)
                        .ToListAsync();

                    List<NotificationMessage> poruka = await context.Notifications.ToListAsync();

                    List<NotificationMessage> procitane = poruka
                        .Where(p => lista.Any(l => l.Notifikacija.MsgID == p.MsgID))
                        .ToList();

                    return procitane;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<NotificationMessage>();
            }
        }

        public async Task<List<NotificationMessage>> VratiNeprocitanePoruke(string korisnickoIme)
        {
            try
            {

                using (var context = dbContextFactory.CreateDbContext())
                {
                    StudentService sService = new StudentService(dbContextFactory);
                    Student student = await sService.PreuzmiStudentaPoKorisnickomImenu(korisnickoIme);

                    List<NotifikacijaStudent> lista = await context.NotifikacijaStudent
                        .Where(x => x.VidjenaPoruka == false && x.Student.ID == student.ID)
                        .ToListAsync();

                    List<NotificationMessage> poruka = await context.Notifications.ToListAsync();

                    List<NotificationMessage> neprocitane = poruka
                        .Where(p => lista.Any(l => l.Notifikacija.MsgID == p.MsgID))
                        .ToList();

                    return neprocitane;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<NotificationMessage>();
            }
        }

        public async Task<NotificationMessage> PreuzmiNotifikaciju(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NotificationMessage mess = await context.Notifications.FirstOrDefaultAsync(x => x.MsgID == ID);
                    return mess;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AzurirajNotifikacije(NotificationMessage m)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    //context.Entry(nastavnoOsoblje).State = EntityState.Detached;

                    context.Notifications.Update(m);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<NotificationMessage>> NeprocitaneUProcitane(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    StudentService sService = new StudentService(dbContextFactory);
                    Student student = await sService.PreuzmiStudentaPoKorisnickomImenu(korisnickoIme);

                    List<NotifikacijaStudent> lista = await context.NotifikacijaStudent
                        .Where(x => x.VidjenaPoruka == false && x.Student.ID == student.ID)
                        .ToListAsync();

                    foreach(var l in lista)
                    {
                        l.VidjenaPoruka = true;
                    }
                    
                    List<NotificationMessage> poruka = await context.Notifications.ToListAsync();

                    List<NotificationMessage> procitane = poruka
                        .Where(p => lista.Any(l => l.Notifikacija.MsgID == p.MsgID))
                        .ToList();

                    return procitane;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<NotificationMessage>();
            }
        }

        public async Task UpdateVidjenaPorukaForNotifications(List<NotificationMessage> notifications)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    foreach (var notification in notifications)
                    {
                        context.Notifications.Update(notification);
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
