using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        Lab_vezba,
        Vanredno_predavanje
    }
    public class Cas
    {
        //public Cas(string naziv, Dan dan, TimeSpan vremeOd, TimeSpan vremeDo, TipCasa tipCasa, Prostorija prostorija, RasporedCasova uRasporeduCasova, Kurs zaKurs)
        //{
        //    Naziv = naziv;
        //    Dan = dan;
        //    VremeOd = vremeOd;
        //    VremeDo = vremeDo;
        //    TipCasa = tipCasa;
        //    Prostorija = prostorija;
        //    URasporeduCasova = uRasporeduCasova;
        //    ZaKurs = zaKurs;
        //}

        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }

        public Dan Dan { get; set; }

        public TimeSpan VremeOd { get; set; }

        public TimeSpan VremeDo { get; set; }

        public TipCasa TipCasa { get; set; }

        public Prostorija Prostorija { get; set; }

        public RasporedCasova URasporeduCasova { get; set; }

        public Kurs ZaKurs { get; set; }
        [NotMapped]
        public NastavnoOsoblje Zakazao { get; set; }
        
        
    }
}
