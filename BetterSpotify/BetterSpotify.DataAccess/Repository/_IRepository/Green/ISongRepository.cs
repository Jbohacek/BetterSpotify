using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository._IRepository.Green
{
    public interface ISongRepository : IRepository<Song>
    {
        public void Update(Song item);
    }
}
