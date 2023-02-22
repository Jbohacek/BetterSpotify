using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository._IRepository.Green
{
    public interface IArtistRepository : IRepository<Artist>
    {
        public void Update(Artist item);
    }
}
