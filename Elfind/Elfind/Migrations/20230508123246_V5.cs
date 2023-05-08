using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elfind.Migrations
{
    /// <inheritdoc />
    public partial class V5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NastavnaOsoblja_Prostorije_KancelarijaID",
                table: "NastavnaOsoblja");

            migrationBuilder.DropForeignKey(
                name: "FK_NastavnaOsoblja_Prostorije_RezervisanaProstorijaID",
                table: "NastavnaOsoblja");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifikacije_NastavnaOsoblja_PosiljalacID",
                table: "Notifikacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Objave_Forum_ForumID",
                table: "Objave");

            migrationBuilder.DropForeignKey(
                name: "FK_Objave_NastavnaOsoblja_OdNastavnogOsobljaID",
                table: "Objave");

            migrationBuilder.DropForeignKey(
                name: "FK_Opcija_Objave_AnketaID",
                table: "Opcija");

            migrationBuilder.DropForeignKey(
                name: "FK_OsobljeKursSpoj_NastavnaOsoblja_NastavnoOsobljeID",
                table: "OsobljeKursSpoj");

            migrationBuilder.DropForeignKey(
                name: "FK_OsobljeRasporedSpoj_NastavnaOsoblja_NastavnoOsobljeID",
                table: "OsobljeRasporedSpoj");

            migrationBuilder.DropForeignKey(
                name: "FK_Prostorije_Zgrada_PripadaZgradiID",
                table: "Prostorije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zgrada",
                table: "Zgrada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opcija",
                table: "Opcija");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objave",
                table: "Objave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NastavnaOsoblja",
                table: "NastavnaOsoblja");

            migrationBuilder.RenameTable(
                name: "Zgrada",
                newName: "Zgrade");

            migrationBuilder.RenameTable(
                name: "Opcija",
                newName: "Opcije");

            migrationBuilder.RenameTable(
                name: "Objave",
                newName: "Objava");

            migrationBuilder.RenameTable(
                name: "NastavnaOsoblja",
                newName: "NastavnoOsoblje");

            migrationBuilder.RenameColumn(
                name: "leftUpY",
                table: "Prostorije",
                newName: "LeftUpY");

            migrationBuilder.RenameColumn(
                name: "leftUpX",
                table: "Prostorije",
                newName: "LeftUpX");

            migrationBuilder.RenameIndex(
                name: "IX_Opcija_AnketaID",
                table: "Opcije",
                newName: "IX_Opcije_AnketaID");

            migrationBuilder.RenameIndex(
                name: "IX_Objave_OdNastavnogOsobljaID",
                table: "Objava",
                newName: "IX_Objava_OdNastavnogOsobljaID");

            migrationBuilder.RenameIndex(
                name: "IX_Objave_ForumID",
                table: "Objava",
                newName: "IX_Objava_ForumID");

            migrationBuilder.RenameIndex(
                name: "IX_NastavnaOsoblja_RezervisanaProstorijaID",
                table: "NastavnoOsoblje",
                newName: "IX_NastavnoOsoblje_RezervisanaProstorijaID");

            migrationBuilder.RenameIndex(
                name: "IX_NastavnaOsoblja_KancelarijaID",
                table: "NastavnoOsoblje",
                newName: "IX_NastavnoOsoblje_KancelarijaID");

            migrationBuilder.AlterColumn<int>(
                name: "Naziv",
                table: "Smerovi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TipProstorije",
                table: "Prostorije",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zgrade",
                table: "Zgrade",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opcije",
                table: "Opcije",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objava",
                table: "Objava",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NastavnoOsoblje",
                table: "NastavnoOsoblje",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NastavnoOsoblje_Prostorije_KancelarijaID",
                table: "NastavnoOsoblje",
                column: "KancelarijaID",
                principalTable: "Prostorije",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NastavnoOsoblje_Prostorije_RezervisanaProstorijaID",
                table: "NastavnoOsoblje",
                column: "RezervisanaProstorijaID",
                principalTable: "Prostorije",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifikacije_NastavnoOsoblje_PosiljalacID",
                table: "Notifikacije",
                column: "PosiljalacID",
                principalTable: "NastavnoOsoblje",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Objava_Forum_ForumID",
                table: "Objava",
                column: "ForumID",
                principalTable: "Forum",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Objava_NastavnoOsoblje_OdNastavnogOsobljaID",
                table: "Objava",
                column: "OdNastavnogOsobljaID",
                principalTable: "NastavnoOsoblje",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opcije_Objava_AnketaID",
                table: "Opcije",
                column: "AnketaID",
                principalTable: "Objava",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OsobljeKursSpoj_NastavnoOsoblje_NastavnoOsobljeID",
                table: "OsobljeKursSpoj",
                column: "NastavnoOsobljeID",
                principalTable: "NastavnoOsoblje",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OsobljeRasporedSpoj_NastavnoOsoblje_NastavnoOsobljeID",
                table: "OsobljeRasporedSpoj",
                column: "NastavnoOsobljeID",
                principalTable: "NastavnoOsoblje",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prostorije_Zgrade_PripadaZgradiID",
                table: "Prostorije",
                column: "PripadaZgradiID",
                principalTable: "Zgrade",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NastavnoOsoblje_Prostorije_KancelarijaID",
                table: "NastavnoOsoblje");

            migrationBuilder.DropForeignKey(
                name: "FK_NastavnoOsoblje_Prostorije_RezervisanaProstorijaID",
                table: "NastavnoOsoblje");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifikacije_NastavnoOsoblje_PosiljalacID",
                table: "Notifikacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Objava_Forum_ForumID",
                table: "Objava");

            migrationBuilder.DropForeignKey(
                name: "FK_Objava_NastavnoOsoblje_OdNastavnogOsobljaID",
                table: "Objava");

            migrationBuilder.DropForeignKey(
                name: "FK_Opcije_Objava_AnketaID",
                table: "Opcije");

            migrationBuilder.DropForeignKey(
                name: "FK_OsobljeKursSpoj_NastavnoOsoblje_NastavnoOsobljeID",
                table: "OsobljeKursSpoj");

            migrationBuilder.DropForeignKey(
                name: "FK_OsobljeRasporedSpoj_NastavnoOsoblje_NastavnoOsobljeID",
                table: "OsobljeRasporedSpoj");

            migrationBuilder.DropForeignKey(
                name: "FK_Prostorije_Zgrade_PripadaZgradiID",
                table: "Prostorije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zgrade",
                table: "Zgrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opcije",
                table: "Opcije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objava",
                table: "Objava");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NastavnoOsoblje",
                table: "NastavnoOsoblje");

            migrationBuilder.RenameTable(
                name: "Zgrade",
                newName: "Zgrada");

            migrationBuilder.RenameTable(
                name: "Opcije",
                newName: "Opcija");

            migrationBuilder.RenameTable(
                name: "Objava",
                newName: "Objave");

            migrationBuilder.RenameTable(
                name: "NastavnoOsoblje",
                newName: "NastavnaOsoblja");

            migrationBuilder.RenameColumn(
                name: "LeftUpY",
                table: "Prostorije",
                newName: "leftUpY");

            migrationBuilder.RenameColumn(
                name: "LeftUpX",
                table: "Prostorije",
                newName: "leftUpX");

            migrationBuilder.RenameIndex(
                name: "IX_Opcije_AnketaID",
                table: "Opcija",
                newName: "IX_Opcija_AnketaID");

            migrationBuilder.RenameIndex(
                name: "IX_Objava_OdNastavnogOsobljaID",
                table: "Objave",
                newName: "IX_Objave_OdNastavnogOsobljaID");

            migrationBuilder.RenameIndex(
                name: "IX_Objava_ForumID",
                table: "Objave",
                newName: "IX_Objave_ForumID");

            migrationBuilder.RenameIndex(
                name: "IX_NastavnoOsoblje_RezervisanaProstorijaID",
                table: "NastavnaOsoblja",
                newName: "IX_NastavnaOsoblja_RezervisanaProstorijaID");

            migrationBuilder.RenameIndex(
                name: "IX_NastavnoOsoblje_KancelarijaID",
                table: "NastavnaOsoblja",
                newName: "IX_NastavnaOsoblja_KancelarijaID");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Smerovi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TipProstorije",
                table: "Prostorije",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zgrada",
                table: "Zgrada",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opcija",
                table: "Opcija",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objave",
                table: "Objave",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NastavnaOsoblja",
                table: "NastavnaOsoblja",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NastavnaOsoblja_Prostorije_KancelarijaID",
                table: "NastavnaOsoblja",
                column: "KancelarijaID",
                principalTable: "Prostorije",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NastavnaOsoblja_Prostorije_RezervisanaProstorijaID",
                table: "NastavnaOsoblja",
                column: "RezervisanaProstorijaID",
                principalTable: "Prostorije",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifikacije_NastavnaOsoblja_PosiljalacID",
                table: "Notifikacije",
                column: "PosiljalacID",
                principalTable: "NastavnaOsoblja",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Objave_Forum_ForumID",
                table: "Objave",
                column: "ForumID",
                principalTable: "Forum",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Objave_NastavnaOsoblja_OdNastavnogOsobljaID",
                table: "Objave",
                column: "OdNastavnogOsobljaID",
                principalTable: "NastavnaOsoblja",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opcija_Objave_AnketaID",
                table: "Opcija",
                column: "AnketaID",
                principalTable: "Objave",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OsobljeKursSpoj_NastavnaOsoblja_NastavnoOsobljeID",
                table: "OsobljeKursSpoj",
                column: "NastavnoOsobljeID",
                principalTable: "NastavnaOsoblja",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OsobljeRasporedSpoj_NastavnaOsoblja_NastavnoOsobljeID",
                table: "OsobljeRasporedSpoj",
                column: "NastavnoOsobljeID",
                principalTable: "NastavnaOsoblja",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prostorije_Zgrada_PripadaZgradiID",
                table: "Prostorije",
                column: "PripadaZgradiID",
                principalTable: "Zgrada",
                principalColumn: "ID");
        }
    }
}
