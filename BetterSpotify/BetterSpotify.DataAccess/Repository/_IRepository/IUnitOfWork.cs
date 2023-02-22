using BetterSpotify.DataAccess.Repository._IRepository.Green;

namespace BetterSpotify.DataAccess.Repository._IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IAlbumRepository Albums { get; }
        IArtistRepository Artist { get; }
        ISongRepository Songs { get; }
        ICategoryRepository Category { get; }
        void Save();
    }
}
