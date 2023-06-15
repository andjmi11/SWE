using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elfind.Migrations
{
    /// <inheritdoc />
    public partial class Anita : Migration
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
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivForuma = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Notifications",
                columns: table => new
                {
                    MsgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MsgBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MsgDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kurs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.MsgID);
                });

            migrationBuilder.CreateTable(
                name: "Smerovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipStudija = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smerovi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zgrade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgrade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ZaGodinu = table.Column<int>(type: "int", nullable: false),
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
                name: "Spratovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZgradaID = table.Column<int>(type: "int", nullable: true),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spratovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Spratovi_Zgrade_ZgradaID",
                        column: x => x.ZgradaID,
                        principalTable: "Zgrade",
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
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indeks = table.Column<int>(type: "int", nullable: false),
                    NaSmeruID = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Studenti_Smerovi_NaSmeruID",
                        column: x => x.NaSmeruID,
                        principalTable: "Smerovi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Prostorije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oznaka = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SpratID = table.Column<int>(type: "int", nullable: true),
                    PripadaZgradiID = table.Column<int>(type: "int", nullable: true),
                    TipProstorije = table.Column<int>(type: "int", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    LeftUpX = table.Column<float>(type: "real", nullable: false),
                    LeftUpY = table.Column<float>(type: "real", nullable: false),
                    DownRightX = table.Column<float>(type: "real", nullable: false),
                    DownRightY = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prostorije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prostorije_Spratovi_SpratID",
                        column: x => x.SpratID,
                        principalTable: "Spratovi",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Prostorije_Zgrade_PripadaZgradiID",
                        column: x => x.PripadaZgradiID,
                        principalTable: "Zgrade",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NotifikacijaStudent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifikacijaMsgID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    VidjenaPoruka = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifikacijaStudent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NotifikacijaStudent_Notifications_NotifikacijaMsgID",
                        column: x => x.NotifikacijaMsgID,
                        principalTable: "Notifications",
                        principalColumn: "MsgID");
                    table.ForeignKey(
                        name: "FK_NotifikacijaStudent_Studenti_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenti",
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
                name: "NastavnoOsoblje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KancelarijaID = table.Column<int>(type: "int", nullable: true),
                    Prisustvo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NastavnoOsoblje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NastavnoOsoblje_Prostorije_KancelarijaID",
                        column: x => x.KancelarijaID,
                        principalTable: "Prostorije",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NotificationProf",
                columns: table => new
                {
                    MsgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MsgBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MsgDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiveEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VidjenaPoruka = table.Column<bool>(type: "bit", nullable: false),
                    NastavnoOsobljeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationProf", x => x.MsgID);
                    table.ForeignKey(
                        name: "FK_NotificationProf_NastavnoOsoblje_NastavnoOsobljeID",
                        column: x => x.NastavnoOsobljeID,
                        principalTable: "NastavnoOsoblje",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Objave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipObjave = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Objave_NastavnoOsoblje_OdNastavnogOsobljaID",
                        column: x => x.OdNastavnogOsobljaID,
                        principalTable: "NastavnoOsoblje",
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
                        name: "FK_OsobljeKursSpoj_NastavnoOsoblje_NastavnoOsobljeID",
                        column: x => x.NastavnoOsobljeID,
                        principalTable: "NastavnoOsoblje",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OsobljeProstorijaRSpoj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProstorijaID = table.Column<int>(type: "int", nullable: true),
                    NastavnoOsobljeID = table.Column<int>(type: "int", nullable: true),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeOd = table.Column<TimeSpan>(type: "time", nullable: false),
                    VremeDo = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobljeProstorijaRSpoj", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OsobljeProstorijaRSpoj_NastavnoOsoblje_NastavnoOsobljeID",
                        column: x => x.NastavnoOsobljeID,
                        principalTable: "NastavnoOsoblje",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OsobljeProstorijaRSpoj_Prostorije_ProstorijaID",
                        column: x => x.ProstorijaID,
                        principalTable: "Prostorije",
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
                        name: "FK_OsobljeRasporedSpoj_NastavnoOsoblje_NastavnoOsobljeID",
                        column: x => x.NastavnoOsobljeID,
                        principalTable: "NastavnoOsoblje",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OsobljeRasporedSpoj_ResporediCasova_RasporedCasovaID",
                        column: x => x.RasporedCasovaID,
                        principalTable: "ResporediCasova",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ObjavaStudent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjavaID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjavaStudent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ObjavaStudent_Objave_ObjavaID",
                        column: x => x.ObjavaID,
                        principalTable: "Objave",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ObjavaStudent_Studenti_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenti",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Opcije",
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
                    table.PrimaryKey("PK_Opcije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Opcije_Objave_AnketaID",
                        column: x => x.AnketaID,
                        principalTable: "Objave",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_NastavnoOsoblje_KancelarijaID",
                table: "NastavnoOsoblje",
                column: "KancelarijaID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationProf_NastavnoOsobljeID",
                table: "NotificationProf",
                column: "NastavnoOsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_NotifikacijaStudent_NotifikacijaMsgID",
                table: "NotifikacijaStudent",
                column: "NotifikacijaMsgID");

            migrationBuilder.CreateIndex(
                name: "IX_NotifikacijaStudent_StudentID",
                table: "NotifikacijaStudent",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjavaStudent_ObjavaID",
                table: "ObjavaStudent",
                column: "ObjavaID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjavaStudent_StudentID",
                table: "ObjavaStudent",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Objave_ForumID",
                table: "Objave",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_Objave_OdNastavnogOsobljaID",
                table: "Objave",
                column: "OdNastavnogOsobljaID");

            migrationBuilder.CreateIndex(
                name: "IX_Opcije_AnketaID",
                table: "Opcije",
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
                name: "IX_OsobljeProstorijaRSpoj_NastavnoOsobljeID",
                table: "OsobljeProstorijaRSpoj",
                column: "NastavnoOsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_OsobljeProstorijaRSpoj_ProstorijaID",
                table: "OsobljeProstorijaRSpoj",
                column: "ProstorijaID");

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
                name: "IX_Prostorije_SpratID",
                table: "Prostorije",
                column: "SpratID");

            migrationBuilder.CreateIndex(
                name: "IX_ResporediCasova_AdministratorID",
                table: "ResporediCasova",
                column: "AdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_ResporediCasova_ZaSmerID",
                table: "ResporediCasova",
                column: "ZaSmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Spratovi_ZgradaID",
                table: "Spratovi",
                column: "ZgradaID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_NaSmeruID",
                table: "Studenti",
                column: "NaSmeruID");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Casovi");

            migrationBuilder.DropTable(
                name: "KursSmerSpoj");

            migrationBuilder.DropTable(
                name: "NotificationProf");

            migrationBuilder.DropTable(
                name: "NotifikacijaStudent");

            migrationBuilder.DropTable(
                name: "ObjavaStudent");

            migrationBuilder.DropTable(
                name: "Opcije");

            migrationBuilder.DropTable(
                name: "OsobljeKursSpoj");

            migrationBuilder.DropTable(
                name: "OsobljeProstorijaRSpoj");

            migrationBuilder.DropTable(
                name: "OsobljeRasporedSpoj");

            migrationBuilder.DropTable(
                name: "StudentKursSpoj");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Objave");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "NastavnoOsoblje");

            migrationBuilder.DropTable(
                name: "ResporediCasova");

            migrationBuilder.DropTable(
                name: "Prostorije");

            migrationBuilder.DropTable(
                name: "Administratori");

            migrationBuilder.DropTable(
                name: "Smerovi");

            migrationBuilder.DropTable(
                name: "Spratovi");

            migrationBuilder.DropTable(
                name: "Zgrade");
        }
    }
}
