using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class Kurs
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }
        [Range(1, 5)]
        public int Godina { get; set; }

        public List<Cas> Casovi = new List<Cas>();
        public List<KursSmer> Smerovi = new List<KursSmer>();
        public List<OsobljeKurs> NastavnoOsoblje = new List<OsobljeKurs>();
        public List<StudentKurs> Studenti = new List<StudentKurs>();
    }
}
