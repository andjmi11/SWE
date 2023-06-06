using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;

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
 
        public List<Objava> Objave = new List<Objava>();
        public List<Notifikacija> Notifikacije = new List<Notifikacija>();
        public List<OsobljeKurs> Kursevi = new List<OsobljeKurs>();
        public List<OsobljeProstorijaR> RezProstorije = new List<OsobljeProstorijaR>();
        public List<OsobljeRaspored> Raspored = new List<OsobljeRaspored>();

    }
}
