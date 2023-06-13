using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class RasporedCasova
    {
        [Key]
        public int ID { get; set; }
        public List<Cas> SpisakCasova { get; set; } = new List<Cas>();
        public Smer ZaSmer { get; set; }
        public int ZaGodinu { get; set; }
        public Administrator Administrator { get; set; } 
        public List<OsobljeRaspored> NastavnoOsoblje { get; set; } = new List<OsobljeRaspored>();
    }
}
