using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class Objava
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TipObjave { get; set; }
        public string Tekst { get; set; }

        public List<Opcija> Opcije { get; set; }
  
        public NastavnoOsoblje OdNastavnogOsoblja { get; set; }
        public Forum Forum { get; set; }
    }
}
