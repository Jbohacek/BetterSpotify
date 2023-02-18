using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterSpotify.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndModefiedSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TbSong");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfRelease",
                table: "TbSong",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "TbSong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbCategory",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(50)", nullable: false),
                    ColorHex = table.Column<string>(type: "Varchar(6)", nullable: false),
                    ImageFile = table.Column<string>(type: "Varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategory", x => x.IdCategory);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbSong_IdCategory",
                table: "TbSong",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_TbSong_tbCategory_IdCategory",
                table: "TbSong",
                column: "IdCategory",
                principalTable: "tbCategory",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbSong_tbCategory_IdCategory",
                table: "TbSong");

            migrationBuilder.DropTable(
                name: "tbCategory");

            migrationBuilder.DropIndex(
                name: "IX_TbSong_IdCategory",
                table: "TbSong");

            migrationBuilder.DropColumn(
                name: "DateOfRelease",
                table: "TbSong");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "TbSong");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "TbSong",
                type: "Int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
