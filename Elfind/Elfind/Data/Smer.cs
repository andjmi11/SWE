namespace Elfind.Data
{
    public class Smer
    {
        public int ID {  get; set; }
        public string Naziv { get; set; }
        public List <Kurs> Kursevi { get; set; }
        public RasporedCasova RasporedCasova { get; set; }

    }
}
