using Microsoft.AspNetCore.Identity;
using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;

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
   
        [Range(10000, 1000000)]
        [Required]
        public int Indeks { get; set; }
        public Smer NaSmeru { get; set; }
        public TipStudija TipStudija { get; set; }
        [Range(1, 5)]
        public int Godina { get; set; }
        public  RasporedCasova RasporedCasova { get; set; }    
        public List<NotifikacijaStudent> Notifikacije { get; set; }
        public List<StudentKurs> Kursevi = new List<StudentKurs>();
    }

}
