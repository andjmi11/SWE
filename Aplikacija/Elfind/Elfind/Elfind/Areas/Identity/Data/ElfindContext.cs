using Elfind.Data.Model;
using Elfind.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace Elfind.Data;

public class ElfindContext : IdentityDbContext<IdentityUser>
{
    public ElfindContext(DbContextOptions<ElfindContext> options)
        : base(options)
    {
    }

    public DbSet<ObjavaStudent> ObjavaStudent { get; set; }
    public DbSet<NotifikacijaStudent> NotifikacijaStudent { get; set; }
    public DbSet<NotificationMessageProf> NotificationProf { get; set; }
    public DbSet<NotificationMessage> Notifications { get; set; }
    public DbSet<Prostorija> Prostorije { get; set; }
    public DbSet<Zgrada> Zgrade { get; set; }
    public DbSet<Student> Studenti { get; set; }
    public DbSet<Smer> Smerovi { get; set; }
    public DbSet<RasporedCasova> ResporediCasova { get; set; }
    public DbSet<Opcija> Opcije { get; set; }
    public DbSet<NastavnoOsoblje> NastavnoOsoblje { get; set; }
    public DbSet<Kurs> Kursevi { get; set; }
    public DbSet<OsobljeKurs> OsobljeKursSpoj { get; set; }
    public DbSet<OsobljeProstorijaR> OsobljeProstorijaRSpoj { get; set; }
    public DbSet<OsobljeRaspored> OsobljeRasporedSpoj { get; set; }
    public DbSet<StudentKurs> StudentKursSpoj { get; set; }
    public DbSet<KursSmer> KursSmerSpoj { get; set; }
    public DbSet<Forum> Forum { get; set; }
    public DbSet<Cas> Casovi { get; set; }
    public DbSet<Administrator> Administratori { get; set; }
    public DbSet<Objava> Objave { get; set; }
    public DbSet<Sprat> Spratovi { get; set; }
    /* protected override void OnModelCreating(ModelBuilder builder)
     {
         base.OnModelCreating(builder);
         // Customize the ASP.NET Identity model and override the defaults if needed.
         // For example, you can rename the ASP.NET Identity table names and more.
         // Add your customizations after calling base.OnModelCreating(builder);
     }*/
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Student>().ToTable("Studenti");
        builder.Entity<NastavnoOsoblje>().ToTable("NastavnoOsoblje");
        builder.Entity<Administrator>().ToTable("Administratori");
    }
}
