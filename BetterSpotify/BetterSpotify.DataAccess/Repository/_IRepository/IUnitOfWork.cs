using BetterSpotify.DataAccess.Repository.IRepository.Green;

namespace BetterSpotify.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IAlbumRepository Albums { get; }
        void Save();
    }
}
