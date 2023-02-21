using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository.Green;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.Green
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly ApplicationDbContext _context;
        public ArtistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(Artist item)
        {
            _context.TbArtists.Update(item);
        }
    }
}
