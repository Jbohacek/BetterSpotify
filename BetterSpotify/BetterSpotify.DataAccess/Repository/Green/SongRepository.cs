using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository.Green;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.Green
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private readonly ApplicationDbContext _context;

        public SongRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(Song item)
        {
            _context.TbSongs.Update(item);
        }

        public new void Add(Song item)
        {
            item.DateOfRelease = DateTime.Now;
            _context.TbSongs.Add(item);
        }
    }
}
