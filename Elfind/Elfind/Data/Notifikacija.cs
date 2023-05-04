namespace Elfind.Data
{
    public class Notifikacija
    {
        public string Poruka { get; set; }

        public NastavnoOsoblje Posiljalac { get; set; }
        public List<Student> Primaoci { get; set; }
    }
}
