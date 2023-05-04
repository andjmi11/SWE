namespace Elfind.Data
{
    public enum TipZgrade
    {
        StaraLamela,
        NovaLamela, 
        GlavnaLamela
    }
    public class Zgrada
    {
        public int ID { get; set; }
        public TipZgrade Tip { get; set; }
        List<Prostorija> Prostorije { get; set;}

    }
}
