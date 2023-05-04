namespace Elfind.Data
{
    public class Kurs
    {
        public int ID { get; set; }

        public string Naziv { get; set; }

        public int Godina { get; set; }

        public List<Cas> Cas = new List<Cas>();

        public List<NastavnoOsoblje> NastavnoOsoblje = new List<NastavnoOsoblje>();
    }
}
