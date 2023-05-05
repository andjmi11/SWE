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

    }
}
