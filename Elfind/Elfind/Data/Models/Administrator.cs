using System.ComponentModel.DataAnnotations;
namespace Elfind.Data.Model
{
    public class Administrator 
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
   
        public List<RasporedCasova> RasporediCasova = new List<RasporedCasova>();

    }
}
