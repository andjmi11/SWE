using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Elfind.Data
{
    public class ElfindDbContext : DbContext
    {
        public ElfindDbContext(DbContextOptions<ElfindDbContext> options) : base(options)
        {

        }
        public DbSet<Prostorija> Prostorije { get; set; }
        public DbSet<Zgrada> Zgrada { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Smer> Smerovi { get; set; }
        public DbSet<RasporedCasova> ResporediCasova { get; set; }
        public DbSet<Objava> Objave { get; set; }
        public DbSet<Notifikacija> Notifikacije { get; set; }
        public DbSet<NastavnoOsoblje> NastavnaOsoblja { get; set; }
        public DbSet<Kurs> Kursevi { get; set; }
        public DbSet<OsobljeKurs> OsobljeKursSpoj { get; set; }
        public DbSet<OsobljeRaspored> OsobljeRasporedSpoj { get; set; }
        public DbSet<StudentKurs> StudentKursSpoj { get; set; }
        public DbSet<KursSmer> KursSmerSpoj { get; set; }
        public DbSet<Forum> Forum { get; set; }
        public DbSet<Cas> Casovi { get; set; }
        public DbSet<Administrator> Administratori { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //        => options.UseSqlServer("Default");
    }
}


