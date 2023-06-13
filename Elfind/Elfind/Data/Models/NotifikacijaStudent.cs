using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class NotifikacijaStudent
    {
        [Key]
        public int ID { get; set; }
        public Notifikacija Notifikacija { get; set; }

        public Student Student { get; set; }
    }
}
