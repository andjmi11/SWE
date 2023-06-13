using System.ComponentModel.DataAnnotations;
namespace Elfind.Data.Model
{
    public class Forum
    {
        [Key]
        public int ID { get; set; }
        public string NazivForuma { get; set; }

        public List<Objava> Objave = new List<Objava>();
    }
}
