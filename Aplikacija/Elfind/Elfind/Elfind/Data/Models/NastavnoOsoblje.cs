using Elfind.Data.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elfind.Data.Model
{
    public class NastavnoOsoblje
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }

        public string Tip { get; set; }

        //public Prostorija RezervisanaProstorija { get; set; }
        public Prostorija Kancelarija { get; set; }
        public bool Prisustvo { get; set; }

       

        public List<NotificationMessageProf> Notifikacije { get; set; } = new List<NotificationMessageProf>();
        public List<Objava> Objave { get; set; } = new List<Objava>();
   
        public List<OsobljeKurs> Kursevi { get; set; } = new List<OsobljeKurs>();
        public List<OsobljeProstorijaR> RezProstorije { get; set; } = new List<OsobljeProstorijaR>();
        public List<OsobljeRaspored> Raspored { get; set; } = new List<OsobljeRaspored>();

        [NotMapped]
        public List<Cas> ListaZakazanihCasova { get; set; } = new List<Cas>();
    }
}
