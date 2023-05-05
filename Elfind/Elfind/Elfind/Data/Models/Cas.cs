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
    public enum TipCasa
    {
        Predavanje, 
        Vezba, 
        Lab_vezba
    }
    public class Cas
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }

        public Dan Dan { get; set; }

        public TimeSpan VremeOd { get; set; }

        public TimeSpan VremeDo { get; set; }

        public TipCasa TipCasa { get; set; }

        public Prostorija Ucionica { get; set; }

        public RasporedCasova RasporedCasova { get; set; }

        public Kurs ZaKurs { get; set; }
    }
}
