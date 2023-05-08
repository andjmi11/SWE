using Elfind.Data.Model;
using Elfind.Data.Models;
using Elfind.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Elfind.Data
{
    public class ElfindDbContext : DbContext
    {
        public ElfindDbContext(DbContextOptions<ElfindDbContext> options) : base(options)
        {

        }
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Cas> Casovi { get; set; }
        public DbSet<Forum> Forum { get; set; }
        public DbSet<Kurs> Kursevi { get; set; }
        public DbSet<KursSmer> KursSmerSpoj { get; set; }
        public DbSet<NastavnoOsoblje> NastavnoOsoblje { get; set; }
        public DbSet<Notifikacija> Notifikacije { get; set; }
        public DbSet<Objava> Objava { get; set; }
        public DbSet<Opcija> Opcije { get; set; }
        public DbSet<OsobljeKurs> OsobljeKursSpoj { get; set; }
        public DbSet<OsobljeRaspored> OsobljeRasporedSpoj { get; set; }
        public DbSet<Prostorija> Prostorije { get; set; }
        public DbSet<RasporedCasova> ResporediCasova { get; set; }
        public DbSet<Smer> Smerovi { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<StudentKurs> StudentKursSpoj { get; set; }
        public DbSet<Zgrada> Zgrade { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //        => options.UseSqlServer("Default");
    }
}


