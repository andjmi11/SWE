using Elfind.Data.Models;
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
        [MaxLength(5)]
        public string Oznaka { get; set; }
        public Sprat Sprat { get; set; }
        public Zgrada PripadaZgradi { get; set; }
        public TipP TipProstorije { get; set; }
        public int Kapacitet { get; set; }
        [Required]
        public float LeftUpX { get; set; }
        [Required]
        public float LeftUpY { get; set; }
        [Required]
        public float DownRightX { get; set; }
        [Required]
        public float DownRightY { get; set; }        

        public List<NastavnoOsoblje> NastavnoOsobljeUKancelariji { get; set; } = new List<NastavnoOsoblje>();

        public List<OsobljeProstorijaR> NastavnoOsobljeR { get; set; } = new List<OsobljeProstorijaR>();
    }
}
