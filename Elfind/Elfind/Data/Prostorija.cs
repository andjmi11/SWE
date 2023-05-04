namespace Elfind.Data
{
    public class Prostorija
    {
        public int ID { get; set; } 

        public string Oznaka { get; set; }
        public int Sprat { get; set; }
        public float DownRightX { get; set; }
        public float DownRightY { get; set; }
        public float leftUpX { get; set; }
        public float leftUpY { get; set; }
        public int Kapacitet { get; set; }
        public string TipProstorije { get; set; }
        public Zgrada PripadaZgradi { get; set; }
        public List <Cas> Casovi = new List <Cas> ();



    }
}
