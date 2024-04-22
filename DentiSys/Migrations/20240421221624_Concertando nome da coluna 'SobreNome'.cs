using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentiSys.Migrations
{
    /// <inheritdoc />
    public partial class ConcertandonomedacolunaSobreNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Dentistas",
                newName: "SobreNome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SobreNome",
                table: "Dentistas",
                newName: "CEP");
        }
    }
}
