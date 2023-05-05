using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
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
        public float leftUpX { get; set; }
        [Required]
        public float leftUpY { get; set; }
        public int Kapacitet { get; set; }
        public string TipProstorije { get; set; }
        public string TipLaboratorije { get; set; }
        public Zgrada PripadaZgradi { get; set; }
        //public List<Cas> Casovi = new List<Cas>();
        public List<NastavnoOsoblje> NastavnoOsobljeZaRezervaciju = new List<NastavnoOsoblje>();



    }
}
