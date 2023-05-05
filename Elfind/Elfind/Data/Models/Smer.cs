using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class Smer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        public List<Kurs> Kursevi { get; set; }
        public RasporedCasova RasporedCasova { get; set; }

    }
}
