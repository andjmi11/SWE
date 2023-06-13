using Castle.Components.DictionaryAdapter;
using Elfind.Data.Model;
using Elfind.Data.Models;
using Elfind.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data
{
    public class NotificationMessageProfService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;

        public NotificationMessageProfService(IDbContextFactory<ElfindContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task SaveNotification(NotificationMessageProf notification)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    context.NotificationProf.Add(notification);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task<List<NotificationMessageProf>> VratiProcitanePoruke(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    NastavnoOsobljeService sService = new NastavnoOsobljeService(dbContextFactory);
                    NastavnoOsoblje student = await sService.PreuzmiNastavnoOsobljePoKorisnickomImenuAsync(korisnickoIme);

                    List<NotificationMessageProf> lista = null;

                    foreach(var not in student.Notifikacije)
                    {
                        if(not.VidjenaPoruka==true)
                                lista.Add(not);
                    }

                
                     return lista;
                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // return new List<NotificationMessage>();
                return null;
            }
        }

        public async Task<List<NotificationMessageProf>> VratiNeprocitanePoruke(string korisnickoIme)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {

                    NastavnoOsobljeService sService = new NastavnoOsobljeService(dbContextFactory);
                    NastavnoOsoblje student = await sService.PreuzmiNastavnoOsobljePoKorisnickomImenuAsync(korisnickoIme);

                    List<NotificationMessageProf> lista = null;

                    foreach (var not in student.Notifikacije)
                    {
                        if (not.VidjenaPoruka == false)
                            lista.Add(not);
                    }


                    return lista;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // return new List<NotificationMessage>();
                return null;
            }
        }


      /*  public async Task<NotificationMessageProf> PreuzmiNotifikaciju(int ID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    //NotificationMessageProf mess = await context.Notifications.FirstOrDefaultAsync(x => x.MsgID == ID);
                    return null;
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

                    foreach (var l in lista)
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
        }*/

    }
}


