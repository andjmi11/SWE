using Elfind.Data.Model;
using Microsoft.EntityFrameworkCore;
namespace Elfind.Data.Models
{
    public class ElfindContext : DbContext
    {
        public required DbSet<Prostorija> Prostorije { get; set; }
        public required DbSet<Zgrada> Zgrada { get; set; }
        public required DbSet<Student> Studenti { get; set; }
        public required DbSet<Smer> Smerovi { get; set; }
        public required DbSet<RasporedCasova> ResporediCasova {  get; set; }
        public required DbSet<Objava> Objave { get; set; }
        public required DbSet<Notifikacija> Notifikacije { get; set; }
        public required DbSet<NastavnoOsoblje> NastavnaOsoblja { get; set; }
        public required DbSet<Kurs> Kursevi { get; set; }
        public required DbSet<Korisnik> Korisnici { get; set; }
        public required DbSet<Forum> Forum { get; set; }
        public required DbSet<Cas> Casovi { get; set; }
        public required DbSet<Administrator> Administratori { get; set; }
        public ElfindContext(DbContextOptions options) : base(options)
        {

        }

    }
}
