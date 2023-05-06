using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class RasporedCasova
    {
        [Key]
        public int ID { get; set; }
        public List<Cas> SpisakCasova = new List<Cas>();
        public Smer ZaSmer { get; set; }
        public Administrator Administrator { get; set; }
    }
}
