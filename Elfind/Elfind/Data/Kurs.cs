using System.ComponentModel.DataAnnotations;

namespace Elfind.Data
{
    public class Kurs
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }
        [Range(1,5)]
        public int Godina { get; set; }

        public List<Cas> Cas = new List<Cas>();

        public List<NastavnoOsoblje> NastavnoOsoblje = new List<NastavnoOsoblje>();
    }
}
