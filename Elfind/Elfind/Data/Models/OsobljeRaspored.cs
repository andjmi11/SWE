using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class OsobljeRaspored
    {
        [Key]
        public int ID { get; set; }
        public NastavnoOsoblje  NastavnoOsoblje { get; set; }
        public RasporedCasova RasporedCasova { get; set; }
    }
}
