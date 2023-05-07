﻿// <auto-generated />
using System;
using Elfind.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProbniProjekat.Migrations
{
    [DbContext(typeof(ElfindContext))]
    partial class ElfindContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Elfind.Data.Model.Cas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Dan")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RasporedCasovaID")
                        .HasColumnType("int");

                    b.Property<string>("TipCasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UProstorijiID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("VremeDo")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("VremeOd")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("RasporedCasovaID");

                    b.HasIndex("UProstorijiID");

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

            modelBuilder.Entity("Elfind.Data.Model.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashLozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Salt")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Korisnici");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Korisnik");

                    b.UseTphMappingStrategy();
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SmerID")
                        .HasColumnType("int");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SmerID");

                    b.HasIndex("StudentID");

                    b.ToTable("Kursevi");
                });

            modelBuilder.Entity("Elfind.Data.Model.Notifikacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PosiljalacID")
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

                    b.Property<int>("OdNastavnogOsobljaID")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipObjave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

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
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("PripadaZgradiID")
                        .HasColumnType("int");

                    b.Property<int>("Sprat")
                        .HasColumnType("int");

                    b.Property<string>("TipLaboratorije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipProstorije")
                        .IsRequired()
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

                    b.HasKey("ID");

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

                    b.Property<int>("RasporedCasovaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RasporedCasovaID");

                    b.ToTable("Smerovi");
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

            modelBuilder.Entity("Elfind.Data.Model.Administrator", b =>
                {
                    b.HasBaseType("Elfind.Data.Model.Korisnik");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("Elfind.Data.Model.NastavnoOsoblje", b =>
                {
                    b.HasBaseType("Elfind.Data.Model.Korisnik");

                    b.Property<int>("KancelarijaID")
                        .HasColumnType("int");

                    b.Property<int?>("RasporedCasovaID")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("KancelarijaID");

                    b.HasIndex("RasporedCasovaID");

                    b.HasDiscriminator().HasValue("NastavnoOsoblje");
                });

            modelBuilder.Entity("Elfind.Data.Model.Student", b =>
                {
                    b.HasBaseType("Elfind.Data.Model.Korisnik");

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<int>("Indeks")
                        .HasColumnType("int");

                    b.Property<int>("RasporedCasovaID")
                        .HasColumnType("int");

                    b.HasIndex("RasporedCasovaID");

                    b.ToTable("Korisnici", t =>
                        {
                            t.Property("RasporedCasovaID")
                                .HasColumnName("Student_RasporedCasovaID");
                        });

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Elfind.Data.Model.Cas", b =>
                {
                    b.HasOne("Elfind.Data.Model.RasporedCasova", "RasporedCasova")
                        .WithMany("SpisakCasova")
                        .HasForeignKey("RasporedCasovaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elfind.Data.Model.Prostorija", "UProstoriji")
                        .WithMany()
                        .HasForeignKey("UProstorijiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RasporedCasova");

                    b.Navigation("UProstoriji");
                });

            modelBuilder.Entity("Elfind.Data.Model.Kurs", b =>
                {
                    b.HasOne("Elfind.Data.Model.Smer", null)
                        .WithMany("Kursevi")
                        .HasForeignKey("SmerID");

                    b.HasOne("Elfind.Data.Model.Student", null)
                        .WithMany("Kursevi")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("Elfind.Data.Model.Notifikacija", b =>
                {
                    b.HasOne("Elfind.Data.Model.NastavnoOsoblje", "Posiljalac")
                        .WithMany()
                        .HasForeignKey("PosiljalacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Posiljalac");
                });

            modelBuilder.Entity("Elfind.Data.Model.Objava", b =>
                {
                    b.HasOne("Elfind.Data.Model.NastavnoOsoblje", "OdNastavnogOsoblja")
                        .WithMany()
                        .HasForeignKey("OdNastavnogOsobljaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OdNastavnogOsoblja");
                });

            modelBuilder.Entity("Elfind.Data.Model.Prostorija", b =>
                {
                    b.HasOne("Elfind.Data.Model.Zgrada", "PripadaZgradi")
                        .WithMany()
                        .HasForeignKey("PripadaZgradiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PripadaZgradi");
                });

            modelBuilder.Entity("Elfind.Data.Model.Smer", b =>
                {
                    b.HasOne("Elfind.Data.Model.RasporedCasova", "RasporedCasova")
                        .WithMany()
                        .HasForeignKey("RasporedCasovaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RasporedCasova");
                });

            modelBuilder.Entity("Elfind.Data.Model.NastavnoOsoblje", b =>
                {
                    b.HasOne("Elfind.Data.Model.Prostorija", "Kancelarija")
                        .WithMany()
                        .HasForeignKey("KancelarijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elfind.Data.Model.RasporedCasova", null)
                        .WithMany("NastavnoOsoblje")
                        .HasForeignKey("RasporedCasovaID");

                    b.Navigation("Kancelarija");
                });

            modelBuilder.Entity("Elfind.Data.Model.Student", b =>
                {
                    b.HasOne("Elfind.Data.Model.RasporedCasova", "RasporedCasova")
                        .WithMany("Studenti")
                        .HasForeignKey("RasporedCasovaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RasporedCasova");
                });

            modelBuilder.Entity("Elfind.Data.Model.RasporedCasova", b =>
                {
                    b.Navigation("NastavnoOsoblje");

                    b.Navigation("SpisakCasova");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("Elfind.Data.Model.Smer", b =>
                {
                    b.Navigation("Kursevi");
                });

            modelBuilder.Entity("Elfind.Data.Model.Student", b =>
                {
                    b.Navigation("Kursevi");
                });
#pragma warning restore 612, 618
        }
    }
}
