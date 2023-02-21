using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository.IRepository.Green;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.Green
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext _context;

        public AlbumRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(Album album)
        {
            _context.Update(album);
        }
    }
}
