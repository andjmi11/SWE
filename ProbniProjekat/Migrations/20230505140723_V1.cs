using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProbniProjekat.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResporediCasova",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResporediCasova", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zgrada",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgrada", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Smerovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RasporedCasovaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smerovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Smerovi_ResporediCasova_RasporedCasovaID",
                        column: x => x.RasporedCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prostorije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oznaka = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Sprat = table.Column<int>(type: "int", nullable: false),
                    DownRightX = table.Column<float>(type: "real", nullable: false),
                    DownRightY = table.Column<float>(type: "real", nullable: false),
                    leftUpX = table.Column<float>(type: "real", nullable: false),
                    leftUpY = table.Column<float>(type: "real", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    TipProstorije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipLaboratorije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PripadaZgradiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prostorije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prostorije_Zgrada_PripadaZgradiID",
                        column: x => x.PripadaZgradiID,
                        principalTable: "Zgrada",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dan = table.Column<int>(type: "int", nullable: false),
                    VremeOd = table.Column<TimeSpan>(type: "time", nullable: false),
                    VremeDo = table.Column<TimeSpan>(type: "time", nullable: false),
                    TipCasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UProstorijiID = table.Column<int>(type: "int", nullable: false),
                    RasporedCasovaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Casovi_Prostorije_UProstorijiID",
                        column: x => x.UProstorijiID,
                        principalTable: "Prostorije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casovi_ResporediCasova_RasporedCasovaID",
                        column: x => x.RasporedCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Salt = table.Column<int>(type: "int", nullable: false),
                    HashLozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KancelarijaID = table.Column<int>(type: "int", nullable: true),
                    RasporedCasovaID = table.Column<int>(type: "int", nullable: true),
                    Indeks = table.Column<int>(type: "int", nullable: true),
                    Godina = table.Column<int>(type: "int", nullable: true),
                    Student_RasporedCasovaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnici_Prostorije_KancelarijaID",
                        column: x => x.KancelarijaID,
                        principalTable: "Prostorije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnici_ResporediCasova_RasporedCasovaID",
                        column: x => x.RasporedCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Korisnici_ResporediCasova_Student_RasporedCasovaID",
                        column: x => x.Student_RasporedCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    SmerID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kursevi_Korisnici_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Korisnici",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Kursevi_Smerovi_SmerID",
                        column: x => x.SmerID,
                        principalTable: "Smerovi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Notifikacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosiljalacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifikacije_Korisnici_PosiljalacID",
                        column: x => x.PosiljalacID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipObjave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdNastavnogOsobljaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objave", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Objave_Korisnici_OdNastavnogOsobljaID",
                        column: x => x.OdNastavnogOsobljaID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_RasporedCasovaID",
                table: "Casovi",
                column: "RasporedCasovaID");

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_UProstorijiID",
                table: "Casovi",
                column: "UProstorijiID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KancelarijaID",
                table: "Korisnici",
                column: "KancelarijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_RasporedCasovaID",
                table: "Korisnici",
                column: "RasporedCasovaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Student_RasporedCasovaID",
                table: "Korisnici",
                column: "Student_RasporedCasovaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_SmerID",
                table: "Kursevi",
                column: "SmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_StudentID",
                table: "Kursevi",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacije_PosiljalacID",
                table: "Notifikacije",
                column: "PosiljalacID");

            migrationBuilder.CreateIndex(
                name: "IX_Objave_OdNastavnogOsobljaID",
                table: "Objave",
                column: "OdNastavnogOsobljaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prostorije_PripadaZgradiID",
                table: "Prostorije",
                column: "PripadaZgradiID");

            migrationBuilder.CreateIndex(
                name: "IX_Smerovi_RasporedCasovaID",
                table: "Smerovi",
                column: "RasporedCasovaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casovi");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "Objave");

            migrationBuilder.DropTable(
                name: "Smerovi");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Prostorije");

            migrationBuilder.DropTable(
                name: "ResporediCasova");

            migrationBuilder.DropTable(
                name: "Zgrada");
        }
    }
}
