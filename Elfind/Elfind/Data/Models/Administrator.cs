using System.ComponentModel.DataAnnotations;
namespace Elfind.Data.Model
{
    public class Administrator 
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorsinickoIme { get; set; }
        public int Salt { get; set; }
        public string HashLozinka { get; set; }
        public List<RasporedCasova> RasporediCasova = new List<RasporedCasova>();

    }
}
