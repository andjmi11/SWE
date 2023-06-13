using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    //public enum Smerovi
    //{
    //    Elektroenergetika,
    //    RacunarstvoIInformatika,
    //    Elektronika_ElektronskaKolaIEmbededSistemi,
    //    Elektronika_MultimedijalneTehnologije,
    //    ElektronskeKomponenteIMikrosistemi,
    //    UpravljanjeSistemima,
    //    KomunikacijeIInformacioneTehnologije
    //}

    public class Smer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        public List<KursSmer> Kursevi { get; set; } = new List<KursSmer>();

        public TipStudija TipStudija { get; set; }

    }
}
