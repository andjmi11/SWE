using System.Globalization;

namespace Elfind.Data
{
    public class Korisnik
    {
        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }
        
        public string KorisnickoIme { get; set; }

        public int salt { get; set; }

        public string HashLozinka { get; set; }
    }
}
