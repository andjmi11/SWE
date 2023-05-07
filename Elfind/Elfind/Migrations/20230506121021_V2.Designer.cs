﻿// <auto-generated />
using System;
using Elfind.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Elfind.Migrations
{
    [DbContext(typeof(ElfindDbContext))]
    [Migration("20230506121021_V2")]
    partial class V2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Elfind.Data.Model.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("HashLozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorsinickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salt")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Administratori");
                });

            modelBuilder.Entity("Elfind.Data.Model.Cas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Dan")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProstorijaID")
                        .HasColumnType("int");

                    b.Property<int>("TipCasa")
                        .HasColumnType("int");

                    b.Property<int?>("URasporeduCasovaID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("VremeDo")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("VremeOd")
                        .HasColumnType("time");

                    b.Property<int?>("ZaKursID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProstorijaID");

                    b.HasIndex("URasporeduCasovaID");

                    b.HasIndex("ZaKursID");

                    b.ToTable("Casovi");
                });

            modelBuilder.Entity("Elfind.Data.Model.Forum", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Forum");
                });

            modelBuilder.Entity("Elfind.Data.Model.Kurs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Kursevi");
                });

            modelBuilder.Entity("Elfind.Data.Model.NastavnoOsoblje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("HashLozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KancelarijaID")
                        .HasColumnType("int");

                    b.Property<string>("KorsinickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RezervisanaProstorijaID")
                        .HasColumnType("int");

                    b.Property<int>("Salt")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KancelarijaID");

                    b.HasIndex("RezervisanaProstorijaID");

                    b.ToTable("NastavnaOsoblja");
                });

            modelBuilder.Entity("Elfind.Data.Model.Notifikacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Poruka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PosiljalacID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PosiljalacID");

                    b.ToTable("Notifikacije");
                });

            modelBuilder.Entity("Elfind.Data.Model.Objava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ForumID")
                        .HasColumnType("int");

                    b.Property<int?>("OdNastavnogOsobljaID")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipObjave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ForumID");

                    b.HasIndex("OdNastavnogOsobljaID");

                    b.ToTable("Objave");
                });

            modelBuilder.Entity("Elfind.Data.Model.Prostorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("DownRightX")
                        .HasColumnType("real");

                    b.Property<float>("DownRightY")
                        .HasColumnType("real");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<string>("Oznaka")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int?>("PripadaZgradiID")
                        .HasColumnType("int");

                    b.Property<string>("Sprat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipLaboratorije")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipProstorije")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("leftUpX")
                        .HasColumnType("real");

                    b.Property<float>("leftUpY")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("PripadaZgradiID");

                    b.ToTable("Prostorije");
                });

            modelBuilder.Entity("Elfind.Data.Model.RasporedCasova", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AdministratorID")
                        .HasColumnType("int");

                    b.Property<int?>("ZaSmerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdministratorID");

                    b.HasIndex("ZaSmerID");

                    b.ToTable("ResporediCasova");
                });

            modelBuilder.Entity("Elfind.Data.Model.Smer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Smerovi");
                });

            modelBuilder.Entity("Elfind.Data.Model.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("HashLozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Indeks")
                        .HasColumnType("int");

                    b.Property<string>("KorsinickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RasporedCasovaID")
                        .HasColumnType("int");

                    b.Property<int>("Salt")
                        .HasColumnType("int");

                    b.Property<int>("TipStudija")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RasporedCasovaID");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("Elfind.Data.Model.Zgrada", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Tip")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Zgrada");
                });

            modelBuilder.Entity("Elfind.Data.Models.KursSmer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("KursID")
                        .HasColumnType("int");

                    b.Property<int?>("SmerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KursID");

                    b.HasIndex("SmerID");

                    b.ToTable("KursSmerSpoj");
                });

            modelBuilder.Entity("Elfind.Data.Models.Opcija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AnketaID")
                        .HasColumnType("int");

                    b.Property<int>("BrojGlasova")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AnketaID");

                    b.ToTable("Opcija");
                });

            modelBuilder.Entity("Elfind.Data.Models.OsobljeKurs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("KursID")
                        .HasColumnType("int");

                    b.Property<int?>("NastavnoOsobljeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KursID");

                    b.HasIndex("NastavnoOsobljeID");

                    b.ToTable("OsobljeKursSpoj");
                });

            modelBuilder.Entity("Elfind.Data.Models.OsobljeRaspored", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("NastavnoOsobljeID")
                        .HasColumnType("int");

                    b.Property<int?>("RasporedCasovaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NastavnoOsobljeID");

                    b.HasIndex("RasporedCasovaID");

                    b.ToTable("OsobljeRasporedSpoj");
                });

            modelBuilder.Entity("Elfind.Data.Models.StudentKurs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("KursID")
                        .HasColumnType("int");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KursID");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentKursSpoj");
                });

            modelBuilder.Entity("Elfind.Data.Model.Cas", b =>
                {
                    b.HasOne("Elfind.Data.Model.Prostorija", "Prostorija")
                        .WithMany()
                        .HasForeignKey("ProstorijaID");

                    b.HasOne("Elfind.Data.Model.RasporedCasova", "URasporeduCasova")
                        .WithMany()
                        .HasForeignKey("URasporeduCasovaID");

                    b.HasOne("Elfind.Data.Model.Kurs", "ZaKurs")
                        .WithMany()
                        .HasForeignKey("ZaKursID");

                    b.Navigation("Prostorija");

                    b.Navigation("URasporeduCasova");

                    b.Navigation("ZaKurs");
                });

            modelBuilder.Entity("Elfind.Data.Model.NastavnoOsoblje", b =>
                {
                    b.HasOne("Elfind.Data.Model.Prostorija", "Kancelarija")
                        .WithMany()
                        .HasForeignKey("KancelarijaID");

                    b.HasOne("Elfind.Data.Model.Prostorija", "RezervisanaProstorija")
                        .WithMany()
                        .HasForeignKey("RezervisanaProstorijaID");

                    b.Navigation("Kancelarija");

                    b.Navigation("RezervisanaProstorija");
                });

            modelBuilder.Entity("Elfind.Data.Model.Notifikacija", b =>
                {
                    b.HasOne("Elfind.Data.Model.NastavnoOsoblje", "Posiljalac")
                        .WithMany("Notifikacije")
                        .HasForeignKey("PosiljalacID");

                    b.Navigation("Posiljalac");
                });

            modelBuilder.Entity("Elfind.Data.Model.Objava", b =>
                {
                    b.HasOne("Elfind.Data.Model.Forum", "Forum")
                        .WithMany()
                        .HasForeignKey("ForumID");

                    b.HasOne("Elfind.Data.Model.NastavnoOsoblje", "OdNastavnogOsoblja")
                        .WithMany()
                        .HasForeignKey("OdNastavnogOsobljaID");

                    b.Navigation("Forum");

                    b.Navigation("OdNastavnogOsoblja");
                });

            modelBuilder.Entity("Elfind.Data.Model.Prostorija", b =>
                {
                    b.HasOne("Elfind.Data.Model.Zgrada", "PripadaZgradi")
                        .WithMany()
                        .HasForeignKey("PripadaZgradiID");

                    b.Navigation("PripadaZgradi");
                });

            modelBuilder.Entity("Elfind.Data.Model.RasporedCasova", b =>
                {
                    b.HasOne("Elfind.Data.Model.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorID");

                    b.HasOne("Elfind.Data.Model.Smer", "ZaSmer")
                        .WithMany()
                        .HasForeignKey("ZaSmerID");

                    b.Navigation("Administrator");

                    b.Navigation("ZaSmer");
                });

            modelBuilder.Entity("Elfind.Data.Model.Student", b =>
                {
                    b.HasOne("Elfind.Data.Model.RasporedCasova", "RasporedCasova")
                        .WithMany()
                        .HasForeignKey("RasporedCasovaID");

                    b.Navigation("RasporedCasova");
                });

            modelBuilder.Entity("Elfind.Data.Models.KursSmer", b =>
                {
                    b.HasOne("Elfind.Data.Model.Kurs", "Kurs")
                        .WithMany()
                        .HasForeignKey("KursID");

                    b.HasOne("Elfind.Data.Model.Smer", "Smer")
                        .WithMany()
                        .HasForeignKey("SmerID");

                    b.Navigation("Kurs");

                    b.Navigation("Smer");
                });

            modelBuilder.Entity("Elfind.Data.Models.Opcija", b =>
                {
                    b.HasOne("Elfind.Data.Model.Objava", "Anketa")
                        .WithMany("Opcije")
                        .HasForeignKey("AnketaID");

                    b.Navigation("Anketa");
                });

            modelBuilder.Entity("Elfind.Data.Models.OsobljeKurs", b =>
                {
                    b.HasOne("Elfind.Data.Model.Kurs", "Kurs")
                        .WithMany()
                        .HasForeignKey("KursID");

                    b.HasOne("Elfind.Data.Model.NastavnoOsoblje", "NastavnoOsoblje")
                        .WithMany()
                        .HasForeignKey("NastavnoOsobljeID");

                    b.Navigation("Kurs");

                    b.Navigation("NastavnoOsoblje");
                });

            modelBuilder.Entity("Elfind.Data.Models.OsobljeRaspored", b =>
                {
                    b.HasOne("Elfind.Data.Model.NastavnoOsoblje", "NastavnoOsoblje")
                        .WithMany()
                        .HasForeignKey("NastavnoOsobljeID");

                    b.HasOne("Elfind.Data.Model.RasporedCasova", "RasporedCasova")
                        .WithMany()
                        .HasForeignKey("RasporedCasovaID");

                    b.Navigation("NastavnoOsoblje");

                    b.Navigation("RasporedCasova");
                });

            modelBuilder.Entity("Elfind.Data.Models.StudentKurs", b =>
                {
                    b.HasOne("Elfind.Data.Model.Kurs", "Kurs")
                        .WithMany()
                        .HasForeignKey("KursID");

                    b.HasOne("Elfind.Data.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Kurs");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Elfind.Data.Model.NastavnoOsoblje", b =>
                {
                    b.Navigation("Notifikacije");
                });

            modelBuilder.Entity("Elfind.Data.Model.Objava", b =>
                {
                    b.Navigation("Opcije");
                });
#pragma warning restore 612, 618
        }
    }
}
