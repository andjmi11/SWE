using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class Opcija
    {
        [Key]
        public int ID { get; set; }
        public string Tekst { get; set; }
        public int BrojGlasova { get; set; }
        public Objava Anketa { get; set; }
    }
}
