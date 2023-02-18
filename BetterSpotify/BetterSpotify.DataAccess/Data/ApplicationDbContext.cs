using BetterSpotify.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace BetterSpotify.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Album> TbAlbums { get; set; } = null!;
        public DbSet<User> TbUsers { get; set; } = null!;
        public DbSet<Artist> TbArtists { get; set; } = null!;
        public DbSet<Song> TbSongs { get; set; } = null!;
        public DbSet<Category> TbCategories { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
