using BetterSpotify.DataAccess.Repository._IRepository.Green;
using BetterSpotify.DataAccess.Repository._IRepository.Yellow;

namespace BetterSpotify.DataAccess.Repository._IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IAlbumRepository Albums { get; }
        IArtistRepository Artist { get; }
        ISongRepository Songs { get; }
        ICategoryRepository Category { get; }
        IRoleRepository Roles { get; }
        bool DataBaseConnected { get; }
        void Save();
    }
}
