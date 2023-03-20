using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterSpotify.Migrations
{
    /// <inheritdoc />
    public partial class LongerPasswordsUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "tbUsers",
                type: "Varchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "tbUsers",
                type: "Varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(1000)");
        }
    }
}
