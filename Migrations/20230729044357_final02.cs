using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Informacioni_sistemi___Projekat.Migrations
{
    /// <inheritdoc />
    public partial class final02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToData",
                table: "AdvertisingPanels",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "FromData",
                table: "AdvertisingPanels",
                newName: "FromDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "AdvertisingPanels",
                newName: "ToData");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "AdvertisingPanels",
                newName: "FromData");
        }
    }
}
