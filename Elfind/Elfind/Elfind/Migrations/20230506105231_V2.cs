using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elfind.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casovi_Prostorije_UcionicaID",
                table: "Casovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Casovi_ResporediCasova_RasporedCasovaID",
                table: "Casovi");

            migrationBuilder.RenameColumn(
                name: "UcionicaID",
                table: "Casovi",
                newName: "URasporeduCasovaID");

            migrationBuilder.RenameColumn(
                name: "RasporedCasovaID",
                table: "Casovi",
                newName: "ProstorijaID");

            migrationBuilder.RenameIndex(
                name: "IX_Casovi_UcionicaID",
                table: "Casovi",
                newName: "IX_Casovi_URasporeduCasovaID");

            migrationBuilder.RenameIndex(
                name: "IX_Casovi_RasporedCasovaID",
                table: "Casovi",
                newName: "IX_Casovi_ProstorijaID");

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
                name: "IX_Opcija_AnketaID",
                table: "Opcija",
                column: "AnketaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Casovi_Prostorije_ProstorijaID",
                table: "Casovi",
                column: "ProstorijaID",
                principalTable: "Prostorije",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Casovi_ResporediCasova_URasporeduCasovaID",
                table: "Casovi",
                column: "URasporeduCasovaID",
                principalTable: "ResporediCasova",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casovi_Prostorije_ProstorijaID",
                table: "Casovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Casovi_ResporediCasova_URasporeduCasovaID",
                table: "Casovi");

            migrationBuilder.DropTable(
                name: "Opcija");

            migrationBuilder.RenameColumn(
                name: "URasporeduCasovaID",
                table: "Casovi",
                newName: "UcionicaID");

            migrationBuilder.RenameColumn(
                name: "ProstorijaID",
                table: "Casovi",
                newName: "RasporedCasovaID");

            migrationBuilder.RenameIndex(
                name: "IX_Casovi_URasporeduCasovaID",
                table: "Casovi",
                newName: "IX_Casovi_UcionicaID");

            migrationBuilder.RenameIndex(
                name: "IX_Casovi_ProstorijaID",
                table: "Casovi",
                newName: "IX_Casovi_RasporedCasovaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Casovi_Prostorije_UcionicaID",
                table: "Casovi",
                column: "UcionicaID",
                principalTable: "Prostorije",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Casovi_ResporediCasova_RasporedCasovaID",
                table: "Casovi",
                column: "RasporedCasovaID",
                principalTable: "ResporediCasova",
                principalColumn: "ID");
        }
    }
}
