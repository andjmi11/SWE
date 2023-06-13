using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    //public enum TipZgrade
    //{
    //    StaraLamela,
    //    NovaLamela,
    //    GlavnaLamela
    //}
    public class Zgrada
    {
        [Key]
        public int ID { get; set; }
        public string Tip { get; set; }
        public List<Prostorija> Prostorije { get; set; } = new List<Prostorija>();
        public List<Sprat> Spratovi { get; set; } = new List<Sprat>();

    }
}
