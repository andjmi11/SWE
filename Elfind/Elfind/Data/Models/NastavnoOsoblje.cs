namespace Elfind.Data.Model
{
    public class NastavnoOsoblje
    {
        public string Tip { get; set; }

        public Prostorija Kancelarija { get; set; }
        public List<Prostorija> ZakazaneProstorije = new List<Prostorija>();

        public List<Objava> Objave = new List<Objava>();

        public List<RasporedCasova> RasporedCasova = new List<RasporedCasova>();

        public List<Kurs> Kursevi = new List<Kurs>();
    }
}
