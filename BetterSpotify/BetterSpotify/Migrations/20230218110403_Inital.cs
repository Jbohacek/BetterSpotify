using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterSpotify.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbAlbum",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "Varchar(2000)", nullable: true),
                    ImageFile = table.Column<string>(type: "Varchar(50)", nullable: false),
                    DateOfPublish = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAlbum", x => x.IdAlbum);
                });

            migrationBuilder.CreateTable(
                name: "TbArtist",
                columns: table => new
                {
                    IdArtist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "Varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "Varchar(5000)", nullable: false),
                    Country = table.Column<string>(type: "Varchar(50)", nullable: false),
                    ActiveFrom = table.Column<DateTime>(type: "Date", nullable: false),
                    ActiveTo = table.Column<DateTime>(type: "Date", nullable: true),
                    ImageFile = table.Column<string>(type: "Varchar(100)", nullable: false),
                    WikiLink = table.Column<string>(type: "Varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbArtist", x => x.IdArtist);
                });

            migrationBuilder.CreateTable(
                name: "tbUsers",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: true),
                    IdArtist = table.Column<int>(type: "int", nullable: true),
                    IdUserProfile = table.Column<int>(type: "int", nullable: true),
                    IdTokenWallet = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "Varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "Varchar(50)", nullable: false),
                    NickName = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Country = table.Column<string>(type: "Varchar(50)", nullable: true),
                    AddId = table.Column<string>(type: "Varchar(4)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "Date", nullable: false),
                    Password = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ActiveAccount = table.Column<bool>(type: "Bit", nullable: false),
                    Verified = table.Column<bool>(type: "Bit", nullable: false),
                    ImageFile = table.Column<string>(type: "Varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsers", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_tbUsers_TbArtist_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "TbArtist",
                        principalColumn: "IdArtist");
                });

            migrationBuilder.CreateTable(
                name: "TbSong",
                columns: table => new
                {
                    IdSong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlbum = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "Varchar(50)", nullable: false),
                    DiscNo = table.Column<int>(type: "Int", nullable: true),
                    TrackNo = table.Column<int>(type: "Int", nullable: true),
                    Duration = table.Column<int>(type: "Int", nullable: false),
                    ImageFile = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Rating = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSong", x => x.IdSong);
                    table.ForeignKey(
                        name: "FK_TbSong_TbAlbum_IdAlbum",
                        column: x => x.IdAlbum,
                        principalTable: "TbAlbum",
                        principalColumn: "IdAlbum");
                    table.ForeignKey(
                        name: "FK_TbSong_tbUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "tbUsers",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbAlbum_IdUser",
                table: "TbAlbum",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TbArtist_IdUser",
                table: "TbArtist",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TbSong_IdAlbum",
                table: "TbSong",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_TbSong_IdUser",
                table: "TbSong",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_tbUsers_IdArtist",
                table: "tbUsers",
                column: "IdArtist");

            migrationBuilder.AddForeignKey(
                name: "FK_TbAlbum_tbUsers_IdUser",
                table: "TbAlbum",
                column: "IdUser",
                principalTable: "tbUsers",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbArtist_tbUsers_IdUser",
                table: "TbArtist",
                column: "IdUser",
                principalTable: "tbUsers",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbArtist_tbUsers_IdUser",
                table: "TbArtist");

            migrationBuilder.DropTable(
                name: "TbSong");

            migrationBuilder.DropTable(
                name: "TbAlbum");

            migrationBuilder.DropTable(
                name: "tbUsers");

            migrationBuilder.DropTable(
                name: "TbArtist");
        }
    }
}
