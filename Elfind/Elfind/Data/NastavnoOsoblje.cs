namespace Elfind.Data
{
    public class NastavnoOsoblje
    {
        public string Tip { get; set; }

        public int ProstorijaID { get; set; }

        public List<Objava> Objave = new List<Objava>();

        public List<RasporedCasova> RasporedCasova = new List<RasporedCasova> ();
        
        public List<Kurs> Kursevi { get; set; }
    }
}
