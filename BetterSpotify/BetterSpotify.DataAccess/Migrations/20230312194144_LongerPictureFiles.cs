using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterSpotify.Migrations
{
    /// <inheritdoc />
    public partial class LongerPictureFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "tbUsers",
                type: "Varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "SongFile",
                table: "TbSong",
                type: "Varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "TbSong",
                type: "Varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "TbCategory",
                type: "Varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WikiLink",
                table: "TbArtist",
                type: "Varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "TbAlbum",
                type: "Varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "tbUsers",
                type: "Varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "SongFile",
                table: "TbSong",
                type: "Varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "TbSong",
                type: "Varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "TbCategory",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WikiLink",
                table: "TbArtist",
                type: "Varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageFile",
                table: "TbAlbum",
                type: "Varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(500)");
        }
    }
}
