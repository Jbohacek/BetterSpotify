using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository._IRepository.Green
{
    public interface IAlbumRepository : IRepository<Album>
    {
        public void Update(Album album);
    }
}
