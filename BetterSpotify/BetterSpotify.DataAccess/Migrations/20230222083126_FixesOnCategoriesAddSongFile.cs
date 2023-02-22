using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterSpotify.Migrations
{
    /// <inheritdoc />
    public partial class FixesOnCategoriesAddSongFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbSong_tbCategory_IdCategory",
                table: "TbSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbCategory",
                table: "tbCategory");

            migrationBuilder.RenameTable(
                name: "tbCategory",
                newName: "TbCategory");

            migrationBuilder.AddColumn<string>(
                name: "SongFile",
                table: "TbSong",
                type: "Varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbCategory",
                table: "TbCategory",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_TbSong_TbCategory_IdCategory",
                table: "TbSong",
                column: "IdCategory",
                principalTable: "TbCategory",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbSong_TbCategory_IdCategory",
                table: "TbSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbCategory",
                table: "TbCategory");

            migrationBuilder.DropColumn(
                name: "SongFile",
                table: "TbSong");

            migrationBuilder.RenameTable(
                name: "TbCategory",
                newName: "tbCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbCategory",
                table: "tbCategory",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_TbSong_tbCategory_IdCategory",
                table: "TbSong",
                column: "IdCategory",
                principalTable: "tbCategory",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
