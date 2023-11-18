using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Informacioni_sistemi___Projekat.Migrations
{
    /// <inheritdoc />
    public partial class kompanija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    companyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyPIB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companySector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyTel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.companyID);
                    table.ForeignKey(
                        name: "FK_Companies_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserID",
                table: "Companies",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
