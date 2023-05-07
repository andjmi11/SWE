using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public enum Dan
    {
        Ponedeljak,
        Utorak,
        Sreda,
        Cetvrtak,
        Petak,
        Subota,
        Nedelja
    }
    public class Cas
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }

        public Dan Dan { get; set; }

        public TimeSpan VremeOd { get; set; }

        public TimeSpan VremeDo { get; set; }

        public string TipCasa { get; set; }

        public Prostorija UProstoriji { get; set; }

        public RasporedCasova RasporedCasova { get; set; }
    }
}
