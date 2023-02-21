namespace BetterSpotify.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        void Save();
    }
}
