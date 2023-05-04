namespace Elfind.Data
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
        public int ID { get; set; }

        public string Naziv { get; set; }

        public Dan Dan { get; set; }

        public TimeSpan VremeOd { get; set; }

        public TimeSpan VremeDo { get; set; }

        public string TipCasa { get; set; }

        public int ProstorijaID { get; set; }

        public int RasporedID { get; set; }
    }
}
