using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        public void Update(User item);

    }

}
