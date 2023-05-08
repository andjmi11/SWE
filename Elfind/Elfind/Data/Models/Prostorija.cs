using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public enum TipP
    {
        Ucionica,
        Amfiteatar,
        Laboratorija,
        Kancelarija
    }
    public class Prostorija
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(4)]
        public string Oznaka { get; set; }

        public string Sprat { get; set; }
        [Required]
        public float DownRightX { get; set; }
        [Required]
        public float DownRightY { get; set; }
        [Required]
        public float LeftUpX { get; set; }
        [Required]
        public float LeftUpY { get; set; }
        public int Kapacitet { get; set; }
        public TipP TipProstorije { get; set; }
        public Zgrada PripadaZgradi { get; set; }
      
        public List<NastavnoOsoblje> NastavnoOsobljeZaRezervaciju = new List<NastavnoOsoblje>();



    }
}
