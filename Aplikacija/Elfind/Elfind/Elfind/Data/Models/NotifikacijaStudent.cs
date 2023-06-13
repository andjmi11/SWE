using Elfind.Data.Model;
using Elfind.Data;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class NotifikacijaStudent
    {
        [Key]
        public int ID { get; set; }
        public NotificationMessage Notifikacija { get; set; }

        public Student Student { get; set; }
        public bool VidjenaPoruka { get; set; } = false;
    }
}
