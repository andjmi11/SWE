using System.ComponentModel.DataAnnotations;

namespace Elfind.Data
{
    public class Notifikacija
    {
        [Key]
        public int ID { get; set; }
        public string Poruka { get; set; }

        public NastavnoOsoblje Posiljalac { get; set; }
        public List<Student> Primaoci = new List<Student>();
    }
}
