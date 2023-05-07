using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class Student : Korisnik
    {
        [Range(10000, 1000000)]
        [Required]
        public int Indeks { get; set; }

        [Range(1, 5)]
        public int Godina { get; set; }
        public RasporedCasova RasporedCasova { get; set; }
        public List<Kurs> Kursevi { get; set; }
    }

}
