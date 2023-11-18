using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Informacioni_sistemi___Projekat.Migrations
{
    /// <inheritdoc />
    public partial class panelsAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Light",
                table: "AdvertisingPanels");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "AdvertisingPanels",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Dimensions",
                table: "AdvertisingPanels",
                newName: "ToData");

            migrationBuilder.AddColumn<string>(
                name: "CityArea",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromData",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "AdvertisingPanels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Lights",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfDays",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityArea",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "FromData",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "Lights",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "AdvertisingPanels");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AdvertisingPanels");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "AdvertisingPanels",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "ToData",
                table: "AdvertisingPanels",
                newName: "Dimensions");

            migrationBuilder.AddColumn<bool>(
                name: "Light",
                table: "AdvertisingPanels",
                type: "bit",
                nullable: true);
        }
    }
}
