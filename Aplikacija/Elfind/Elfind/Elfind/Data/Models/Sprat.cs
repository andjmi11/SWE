using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class Sprat
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public Zgrada Zgrada { get; set; }
        public string Slika { get; set; }
        public List<Prostorija> ListaProstorija { get; set; } = new List<Prostorija>();
        
    }
}
