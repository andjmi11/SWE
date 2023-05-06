using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public enum TipZgrade
    {
        StaraLamela,
        NovaLamela,
        GlavnaLamela
    }
    public class Zgrada
    {
        [Key]
        public int ID { get; set; }
        public TipZgrade Tip { get; set; }
        List<Prostorija> Prostorije = new List<Prostorija>();

    }
}
