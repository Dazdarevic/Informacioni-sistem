using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Informacioni_sistemi___Projekat.Migrations
{
    /// <inheritdoc />
    public partial class final01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdvertisementPhoto",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AdvertisingPanels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisingPanels_UserID",
                table: "AdvertisingPanels",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisingPanels_Users_UserID",
                table: "AdvertisingPanels",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisingPanels_Users_UserID",
                table: "AdvertisingPanels");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisingPanels_UserID",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "AdvertisementPhoto",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AdvertisingPanels");
        }
    }
}
