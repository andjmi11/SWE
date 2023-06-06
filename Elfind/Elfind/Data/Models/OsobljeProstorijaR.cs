using Elfind.Data.Model;

namespace Elfind.Data.Models
{
    public class OsobljeProstorijaR
    {
        public int ID { get; set; }
        public Prostorija Prostorija { get; set; }
        public NastavnoOsoblje NastavnoOsoblje { get; set; }
        public DateTime datum { get; set; }
        public TimeSpan VremeOd { get; set; }
        public TimeSpan VremeDo { get; set; }

    }
}
