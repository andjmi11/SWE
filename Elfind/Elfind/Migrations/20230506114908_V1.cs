using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elfind.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administratori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorsinickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<int>(type: "int", nullable: false),
                    HashLozinka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratori", x => x.ID);
                });

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
                name: "Kursevi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Smerovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smerovi", x => x.ID);
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
                name: "KursSmerSpoj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursID = table.Column<int>(type: "int", nullable: true),
                    SmerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursSmerSpoj", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KursSmerSpoj_Kursevi_KursID",
                        column: x => x.KursID,
                        principalTable: "Kursevi",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KursSmerSpoj_Smerovi_SmerID",
                        column: x => x.SmerID,
                        principalTable: "Smerovi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ResporediCasova",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZaSmerID = table.Column<int>(type: "int", nullable: true),
                    AdministratorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResporediCasova", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResporediCasova_Administratori_AdministratorID",
                        column: x => x.AdministratorID,
                        principalTable: "Administratori",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ResporediCasova_Smerovi_ZaSmerID",
                        column: x => x.ZaSmerID,
                        principalTable: "Smerovi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Prostorije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oznaka = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Sprat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownRightX = table.Column<float>(type: "real", nullable: false),
                    DownRightY = table.Column<float>(type: "real", nullable: false),
                    leftUpX = table.Column<float>(type: "real", nullable: false),
                    leftUpY = table.Column<float>(type: "real", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    TipProstorije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipLaboratorije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PripadaZgradiID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prostorije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prostorije_Zgrada_PripadaZgradiID",
                        column: x => x.PripadaZgradiID,
                        principalTable: "Zgrada",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorsinickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<int>(type: "int", nullable: false),
                    HashLozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indeks = table.Column<int>(type: "int", nullable: false),
                    TipStudija = table.Column<int>(type: "int", nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    RasporedCasovaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Studenti_ResporediCasova_RasporedCasovaID",
                        column: x => x.RasporedCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Casovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dan = table.Column<int>(type: "int", nullable: false),
                    VremeOd = table.Column<TimeSpan>(type: "time", nullable: false),
                    VremeDo = table.Column<TimeSpan>(type: "time", nullable: false),
                    TipCasa = table.Column<int>(type: "int", nullable: false),
                    ProstorijaID = table.Column<int>(type: "int", nullable: true),
                    URasporeduCasovaID = table.Column<int>(type: "int", nullable: true),
                    ZaKursID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Casovi_Kursevi_ZaKursID",
                        column: x => x.ZaKursID,
                        principalTable: "Kursevi",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Casovi_Prostorije_ProstorijaID",
                        column: x => x.ProstorijaID,
                        principalTable: "Prostorije",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Casovi_ResporediCasova_URasporeduCasovaID",
                        column: x => x.URasporeduCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NastavnaOsoblja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorsinickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<int>(type: "int", nullable: false),
                    HashLozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RezervisanaProstorijaID = table.Column<int>(type: "int", nullable: true),
                    KancelarijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NastavnaOsoblja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NastavnaOsoblja_Prostorije_KancelarijaID",
                        column: x => x.KancelarijaID,
                        principalTable: "Prostorije",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NastavnaOsoblja_Prostorije_RezervisanaProstorijaID",
                        column: x => x.RezervisanaProstorijaID,
                        principalTable: "Prostorije",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentKursSpoj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    KursID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentKursSpoj", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentKursSpoj_Kursevi_KursID",
                        column: x => x.KursID,
                        principalTable: "Kursevi",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StudentKursSpoj_Studenti_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenti",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Notifikacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosiljalacID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifikacije_NastavnaOsoblja_PosiljalacID",
                        column: x => x.PosiljalacID,
                        principalTable: "NastavnaOsoblja",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Objave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipObjave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdNastavnogOsobljaID = table.Column<int>(type: "int", nullable: true),
                    ForumID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objave", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Objave_Forum_ForumID",
                        column: x => x.ForumID,
                        principalTable: "Forum",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Objave_NastavnaOsoblja_OdNastavnogOsobljaID",
                        column: x => x.OdNastavnogOsobljaID,
                        principalTable: "NastavnaOsoblja",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OsobljeKursSpoj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NastavnoOsobljeID = table.Column<int>(type: "int", nullable: true),
                    KursID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobljeKursSpoj", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OsobljeKursSpoj_Kursevi_KursID",
                        column: x => x.KursID,
                        principalTable: "Kursevi",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OsobljeKursSpoj_NastavnaOsoblja_NastavnoOsobljeID",
                        column: x => x.NastavnoOsobljeID,
                        principalTable: "NastavnaOsoblja",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OsobljeRasporedSpoj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NastavnoOsobljeID = table.Column<int>(type: "int", nullable: true),
                    RasporedCasovaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobljeRasporedSpoj", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OsobljeRasporedSpoj_NastavnaOsoblja_NastavnoOsobljeID",
                        column: x => x.NastavnoOsobljeID,
                        principalTable: "NastavnaOsoblja",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OsobljeRasporedSpoj_ResporediCasova_RasporedCasovaID",
                        column: x => x.RasporedCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Opcija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojGlasova = table.Column<int>(type: "int", nullable: false),
                    AnketaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Opcija_Objave_AnketaID",
                        column: x => x.AnketaID,
                        principalTable: "Objave",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_ProstorijaID",
                table: "Casovi",
                column: "ProstorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_URasporeduCasovaID",
                table: "Casovi",
                column: "URasporeduCasovaID");

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_ZaKursID",
                table: "Casovi",
                column: "ZaKursID");

            migrationBuilder.CreateIndex(
                name: "IX_KursSmerSpoj_KursID",
                table: "KursSmerSpoj",
                column: "KursID");

            migrationBuilder.CreateIndex(
                name: "IX_KursSmerSpoj_SmerID",
                table: "KursSmerSpoj",
                column: "SmerID");

            migrationBuilder.CreateIndex(
                name: "IX_NastavnaOsoblja_KancelarijaID",
                table: "NastavnaOsoblja",
                column: "KancelarijaID");

            migrationBuilder.CreateIndex(
                name: "IX_NastavnaOsoblja_RezervisanaProstorijaID",
                table: "NastavnaOsoblja",
                column: "RezervisanaProstorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacije_PosiljalacID",
                table: "Notifikacije",
                column: "PosiljalacID");

            migrationBuilder.CreateIndex(
                name: "IX_Objave_ForumID",
                table: "Objave",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_Objave_OdNastavnogOsobljaID",
                table: "Objave",
                column: "OdNastavnogOsobljaID");

            migrationBuilder.CreateIndex(
                name: "IX_Opcija_AnketaID",
                table: "Opcija",
                column: "AnketaID");

            migrationBuilder.CreateIndex(
                name: "IX_OsobljeKursSpoj_KursID",
                table: "OsobljeKursSpoj",
                column: "KursID");

            migrationBuilder.CreateIndex(
                name: "IX_OsobljeKursSpoj_NastavnoOsobljeID",
                table: "OsobljeKursSpoj",
                column: "NastavnoOsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_OsobljeRasporedSpoj_NastavnoOsobljeID",
                table: "OsobljeRasporedSpoj",
                column: "NastavnoOsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_OsobljeRasporedSpoj_RasporedCasovaID",
                table: "OsobljeRasporedSpoj",
                column: "RasporedCasovaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prostorije_PripadaZgradiID",
                table: "Prostorije",
                column: "PripadaZgradiID");

            migrationBuilder.CreateIndex(
                name: "IX_ResporediCasova_AdministratorID",
                table: "ResporediCasova",
                column: "AdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_ResporediCasova_ZaSmerID",
                table: "ResporediCasova",
                column: "ZaSmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_RasporedCasovaID",
                table: "Studenti",
                column: "RasporedCasovaID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentKursSpoj_KursID",
                table: "StudentKursSpoj",
                column: "KursID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentKursSpoj_StudentID",
                table: "StudentKursSpoj",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casovi");

            migrationBuilder.DropTable(
                name: "KursSmerSpoj");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "Opcija");

            migrationBuilder.DropTable(
                name: "OsobljeKursSpoj");

            migrationBuilder.DropTable(
                name: "OsobljeRasporedSpoj");

            migrationBuilder.DropTable(
                name: "StudentKursSpoj");

            migrationBuilder.DropTable(
                name: "Objave");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "NastavnaOsoblja");

            migrationBuilder.DropTable(
                name: "ResporediCasova");

            migrationBuilder.DropTable(
                name: "Prostorije");

            migrationBuilder.DropTable(
                name: "Administratori");

            migrationBuilder.DropTable(
                name: "Smerovi");

            migrationBuilder.DropTable(
                name: "Zgrada");
        }
    }
}
