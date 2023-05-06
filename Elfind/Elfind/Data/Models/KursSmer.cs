using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class KursSmer
    {
        [Key]
        public int ID { get; set; }
        public Kurs Kurs { get; set; }
        public Smer Smer { get; set; }
    }
}
