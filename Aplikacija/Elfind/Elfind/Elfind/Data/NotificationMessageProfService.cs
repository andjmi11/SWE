using Castle.Components.DictionaryAdapter;
using Elfind.Data.Model;
using Elfind.Data.Models;
using Elfind.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Elfind.Data
{
    public class NotificationMessageProfService
    {
        private IDbContextFactory<ElfindContext> dbContextFactory;
        private NastavnoOsobljeService _nasobljeService;

        public NotificationMessageProfService(IDbContextFactory<ElfindContext> dbContextFactory, NastavnoOsobljeService nastavno)
        {
            this.dbContextFactory = dbContextFactory;
            _nasobljeService = nastavno;

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

        public async Task DodajNotifikacijuNastavnomOsoblju(NotificationMessageProf notification)
        {
            List<NastavnoOsoblje> no = await _nasobljeService.VratiSveNastavnikeAsync();

            foreach (var n in no)
            {
                n.Notifikacije.Add(notification);
                await _nasobljeService.AzurirajNastavnoOsobljeAsync(n); // Ažurirajte objekat nastavnog osoblja u bazi podataka
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

                    List<NotificationMessageProf> lista = new List<NotificationMessageProf>();

                    foreach(var not in student.Notifikacije)
                    {
                       // not.VidjenaPoruka = true;
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
                return new List<NotificationMessageProf>();
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

                    List<NotificationMessageProf> lista = new List<NotificationMessageProf>();

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
                return new List<NotificationMessageProf>();
            }
        }

        public async Task SetPorukaVidjena(int msgId, int nID)
        {
            try
            {
                using (var context = dbContextFactory.CreateDbContext())
                {
                    NastavnoOsoblje osoblje = await _nasobljeService.PreuzmiNastavnoOsobljeAsync(nID);
                    //NastavnoOsoblje nast = await context.NastavnoOsoblje.Include(x=>x.Notifikacije).FirstOrDefaultAsync(x => x.ID == nID);

                    foreach(var n in osoblje.Notifikacije)
                    {
                        if (n.MsgID == msgId)
                        {
                            n.VidjenaPoruka = true;
                            context.Entry(n).State = EntityState.Modified;
                        }
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


