using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.IRepository.Green
{
    public interface IAlbumRepository : IRepository<Album>
    {
        public void Update(Album album);
    }
}
