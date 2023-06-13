using Elfind.Data.Model;
using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elfind.Data
{
    public class NotificationMessageProf
    {
        [Key]
        public int MsgID { get; set; }
        public string SenderName { get; set; }
        public string MsgBody { get; set; }
        public DateTime MsgDate { get; set; } = DateTime.Now;

        public string ReceiveEmail{ get; set; }
        public string Cas { get; set; }
        public bool VidjenaPoruka { get; set; } = false;
    }
}
