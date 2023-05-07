using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elfind.Migrations
{
    /// <inheritdoc />
    public partial class ObrisanTipLab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipLaboratorije",
                table: "Prostorije");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipLaboratorije",
                table: "Prostorije",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
