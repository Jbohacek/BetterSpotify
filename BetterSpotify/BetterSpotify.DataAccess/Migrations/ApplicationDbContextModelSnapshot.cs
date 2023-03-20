﻿// <auto-generated />
using System;
using BetterSpotify.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BetterSpotify.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BetterSpotify.Models.Database.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlbum"));

                    b.Property<DateTime>("DateOfPublish")
                        .HasColumnType("Date");

                    b.Property<string>("Description")
                        .HasColumnType("Varchar(2000)");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("ImageFile")
                        .IsRequired()
                        .HasColumnType("Varchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdUser");

                    b.ToTable("TbAlbum");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Artist", b =>
                {
                    b.Property<int>("IdArtist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtist"));

                    b.Property<DateTime>("ActiveFrom")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("ActiveTo")
                        .HasColumnType("Date");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("Varchar(5000)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("ImageFile")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("WikiLink")
                        .HasColumnType("Varchar(500)");

                    b.HasKey("IdArtist");

                    b.HasIndex("IdUser");

                    b.ToTable("TbArtist");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"));

                    b.Property<string>("ColorHex")
                        .IsRequired()
                        .HasColumnType("Varchar(6)");

                    b.Property<string>("ImageFile")
                        .HasColumnType("Varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("IdCategory");

                    b.ToTable("TbCategory");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Song", b =>
                {
                    b.Property<int>("IdSong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSong"));

                    b.Property<DateTime>("DateOfRelease")
                        .HasColumnType("Date");

                    b.Property<int?>("DiscNo")
                        .HasColumnType("Int");

                    b.Property<int>("Duration")
                        .HasColumnType("Int");

                    b.Property<int?>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("ImageFile")
                        .IsRequired()
                        .HasColumnType("Varchar(500)");

                    b.Property<bool>("NoCopyRight")
                        .HasColumnType("Bit");

                    b.Property<string>("SongFile")
                        .IsRequired()
                        .HasColumnType("Varchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<int?>("TrackNo")
                        .HasColumnType("Int");

                    b.Property<bool>("Verified")
                        .HasColumnType("Bit");

                    b.HasKey("IdSong");

                    b.HasIndex("IdAlbum");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdUser");

                    b.ToTable("TbSong");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<bool>("ActiveAccount")
                        .HasColumnType("Bit");

                    b.Property<string>("AddId")
                        .IsRequired()
                        .HasColumnType("Varchar(4)");

                    b.Property<string>("Country")
                        .HasColumnType("Varchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<int?>("IdArtist")
                        .HasColumnType("int");

                    b.Property<int?>("IdRole")
                        .HasColumnType("int");

                    b.Property<int?>("IdTokenWallet")
                        .HasColumnType("int");

                    b.Property<int?>("IdUserProfile")
                        .HasColumnType("int");

                    b.Property<string>("ImageFile")
                        .IsRequired()
                        .HasColumnType("Varchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("Varchar(1000)");

                    b.Property<bool>("Verified")
                        .HasColumnType("Bit");

                    b.HasKey("IdUser");

                    b.HasIndex("IdArtist");

                    b.ToTable("tbUsers");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Album", b =>
                {
                    b.HasOne("BetterSpotify.Models.Database.User", "User")
                        .WithMany("Albums")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Artist", b =>
                {
                    b.HasOne("BetterSpotify.Models.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Song", b =>
                {
                    b.HasOne("BetterSpotify.Models.Database.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("IdAlbum");

                    b.HasOne("BetterSpotify.Models.Database.Category", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BetterSpotify.Models.Database.User", "User")
                        .WithMany("Songs")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.User", b =>
                {
                    b.HasOne("BetterSpotify.Models.Database.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("IdArtist");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.Category", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("BetterSpotify.Models.Database.User", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
