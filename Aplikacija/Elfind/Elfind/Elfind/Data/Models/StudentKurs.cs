using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Models
{
    public class StudentKurs
    {
        [Key]
        public int ID { get; set; }
        public Student Student { get; set; }
        public Kurs Kurs {  get; set; }
    }
}
