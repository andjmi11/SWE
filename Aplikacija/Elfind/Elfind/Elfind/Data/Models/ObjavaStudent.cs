using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class ObjavaStudent
    {
        [Key]
        public int ID { get; set; }
        public Objava Objava { get; set; }
        public Student Student { get; set; }

    }
}
