using Elfind.Data.Models;
using Elfind.Data.Services;
using Elfind.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Elfind.Data
{
    public class NotificationMessage
    {
        [Key]
        public int MsgID { get; set; }
        public string SenderName { get; set; }
        public string MsgBody { get; set; }
        public DateTime MsgDate { get; set; }=DateTime.Now;
        public List<NotifikacijaStudent> Primaoci { get; set; } = new List<NotifikacijaStudent>();
        //treba mi dakle smerovi na koje saljem i predmet
        [NotMapped]
        public string[] Smerovi { get; set; }
        public string Kurs { get; set; }

    }


}
