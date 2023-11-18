using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Informacioni_sistemi___Projekat.Migrations
{
    /// <inheritdoc />
    public partial class gradskapodrucja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityArea",
                table: "AdvertisingPanels");

            migrationBuilder.CreateTable(
                name: "CityAreas",
                columns: table => new
                {
                    CityAreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityAreas", x => x.CityAreaID);
                    table.ForeignKey(
                        name: "FK_CityAreas_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityAreas_CityID",
                table: "CityAreas",
                column: "CityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityAreas");

            migrationBuilder.AddColumn<string>(
                name: "CityArea",
                table: "AdvertisingPanels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
