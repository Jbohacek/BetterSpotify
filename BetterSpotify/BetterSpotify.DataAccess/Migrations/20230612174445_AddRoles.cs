using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterSpotify.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbRoles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(50)", nullable: false),
                    ColorHex = table.Column<string>(type: "Varchar(6)", nullable: false),
                    Prefix = table.Column<string>(type: "Varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRoles", x => x.IdRole);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbUsers_IdRole",
                table: "tbUsers",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_tbUsers_tbRoles_IdRole",
                table: "tbUsers",
                column: "IdRole",
                principalTable: "tbRoles",
                principalColumn: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbUsers_tbRoles_IdRole",
                table: "tbUsers");

            migrationBuilder.DropTable(
                name: "tbRoles");

            migrationBuilder.DropIndex(
                name: "IX_tbUsers_IdRole",
                table: "tbUsers");
        }
    }
}
