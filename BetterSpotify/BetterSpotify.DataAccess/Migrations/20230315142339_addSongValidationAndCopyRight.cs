using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterSpotify.Migrations
{
    /// <inheritdoc />
    public partial class addSongValidationAndCopyRight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoCopyRight",
                table: "TbSong",
                type: "Bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "TbSong",
                type: "Bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoCopyRight",
                table: "TbSong");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "TbSong");
        }
    }
}
