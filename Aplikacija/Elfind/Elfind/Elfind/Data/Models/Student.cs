using Microsoft.AspNetCore.Identity;
using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elfind.Data.Model
{
    public enum TipStudija
    {
        OAS,
        MAS,
        DAS
    }
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        [Required]
        [Range(10000, 99999, ErrorMessage = "Vrednost mora imati tačno 5 cifara.")]
        public int Indeks { get; set; }
        public Smer NaSmeru { get; set; }
        public TipStudija TipStudija { get; set; }
        [Range(1, 5)]
        public int Godina { get; set; }
        public RasporedCasova RasporedCasova { get; set; }
        public List<NotifikacijaStudent> Notifikacije { get; set; } = new List<NotifikacijaStudent>();
        public List<StudentKurs> Kursevi { get; set; } = new List<StudentKurs>();
        public List<ObjavaStudent> Objave { get; set; } = new List<ObjavaStudent>();

        [NotMapped]
        public List<Cas> ListaZakazanihCasova { get; set; }=new List<Cas>();
    }

}
