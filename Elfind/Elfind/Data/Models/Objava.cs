using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class Objava
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TipObjave { get; set; }
        public string Tekst { get; set; }

        public Dictionary<string, int> ListaOpcija = new Dictionary<string, int>();
        public NastavnoOsoblje OdNastavnogOsoblja { get; set; }

    }
}
