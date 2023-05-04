using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Elfind.Data
{
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Ime { get; set; }

        [MaxLength(50)]
        public string Prezime { get; set; }

        [MaxLength(25)]
        public string KorisnickoIme { get; set; }

        public int Salt { get; set; }
        public string HashLozinka { get; set; }
    }
}
