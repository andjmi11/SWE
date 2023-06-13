using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Elfind.Data.Model;
using Elfind.Data.Services;
using Elfind.Data.Models;
using Elfind.Data;
using Microsoft.EntityFrameworkCore;

namespace Elfind.Data
{
    public class NotificationHub : Hub
    {
        private readonly NotificationMessageService _notificationService;
        private readonly StudentService studentService;
        private readonly NotifikacijaStudentService notifikacijaStudentService;
        private readonly ElfindContext _context;
        private readonly IDbContextFactory<ElfindContext> _dbContextFactory;

        private readonly NotificationMessageProfService _notificationMessageProfService;
        private readonly NastavnoOsobljeService _nastavnoOsobljeService;
        
        //moze li drugi konstruktor?
 
        public NotificationHub(NotificationMessageProfService notificationMessageProfService, NastavnoOsobljeService nastavnoOsobljeService, NotificationMessageService notificationService, StudentService s, NotifikacijaStudentService ns, ElfindContext context, IDbContextFactory<ElfindContext> db)
        {
            _notificationMessageProfService = notificationMessageProfService;
            _nastavnoOsobljeService = nastavnoOsobljeService;
            _notificationService = notificationService;
            studentService = s;
            notifikacijaStudentService = ns;
            _context = context;
            _dbContextFactory = db;
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendForZahtev(string user, string message,string cas)
        {
            var notification = new NotificationMessageProf
            {
                SenderName = user,
                MsgBody = message,
                MsgDate = DateTime.Now,
                Cas = cas
            };

            await _notificationMessageProfService.SaveNotification(notification);
            List<NastavnoOsoblje> no = await _nastavnoOsobljeService.VratiSveNastavnikeAsync();
            foreach(var n in no)
            {
                n.Notifikacije.Add(notification);
            }

            await Clients.Group("NastavnoOsoblje").SendAsync("ReceiveMessageForZahtev", user, message, cas);
        }
        public async Task SendNotificationForObjava(string user, string message, string[] sm, string k)
        {
            var notification = new NotificationMessage
            {
                SenderName = user,
                MsgBody = message,
                MsgDate = DateTime.Now,
                Smerovi = sm,
                Kurs = k
            };


            await _notificationService.SaveNotification(notification);

            foreach (var s in notification.Smerovi)
            {
                List<Student> studenti = await studentService.VratiStudentePoSmeru(s);
                foreach (var student in studenti)
                {
                    NotifikacijaStudent nt = new NotifikacijaStudent()
                    {
                        Notifikacija = notification,
                        Student = student
                    };

                    await notifikacijaStudentService.DodajNotifikacijaStudent(nt);
                }

                await Clients.Group(s).SendAsync("ReceiveMessage", user, message, sm, k);
            }
        }
        public async Task SendNotificationForZakazivanje(string user, string message, string[] sm, string kurs)
        {
            var notification = new NotificationMessage
            {
                SenderName = user,
                MsgBody = message,
                MsgDate = DateTime.Now,
                Kurs = kurs
            };

            await _notificationService.SaveNotification(notification);

            List<Student> studenti = await studentService.VratiSveStudente();

            List<KursSmer> kursevi = await _context.KursSmerSpoj.Where(x => x.Kurs.Naziv == kurs)
                .Include(x => x.Kurs)
                .Include(x => x.Smer)
                .ToListAsync();
            foreach (var s in studenti)
            {
                foreach (var k in kursevi)
                {
                    if (s.NaSmeru.Naziv == k.Smer.Naziv)
                    {
                        NotifikacijaStudent nt = new NotifikacijaStudent()
                        {
                            Notifikacija = notification,
                            Student = s
                        };

                        await notifikacijaStudentService.DodajNotifikacijaStudent(nt);
                    }

                }

            }
            await Clients.Group(kurs).SendAsync("ReceiveMessage", user, message, sm, kurs);
        }
    }
}