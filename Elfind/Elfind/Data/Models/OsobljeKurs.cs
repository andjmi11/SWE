using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class OsobljeKurs
    {
        [Key]
        public int ID { get; set; }
        public NastavnoOsoblje  NastavnoOsoblje { get; set; }
        public Kurs Kurs {  get; set; }
    }
}
