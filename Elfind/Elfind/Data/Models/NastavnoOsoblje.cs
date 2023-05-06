using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class NastavnoOsoblje
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorsinickoIme { get; set; }
        public int Salt { get; set; }
        public string HashLozinka { get; set; }

        public string Tip { get; set; }

        public Prostorija RezervisanaProstorija { get; set; }
        public Prostorija Kancelarija { get; set; }
 
        public List<Objava> Objave = new List<Objava>();
        public List<Notifikacija> Notifikacije { get; set; }
    }
}
