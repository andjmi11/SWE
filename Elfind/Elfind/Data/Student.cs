namespace Elfind.Data
{
    public class Student : Korisnik
    {
        public int Indeks { get; set; }
        public int Godina { get; set; }
        public RasporedCasova RasporedCasova { get; set; }
        public List<Kurs> Kursevi { get; set; }
    }

}
