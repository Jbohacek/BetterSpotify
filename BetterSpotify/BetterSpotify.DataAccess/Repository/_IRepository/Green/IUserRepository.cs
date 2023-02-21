using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.IRepository.Green
{
    public interface IUserRepository : IRepository<User>
    {
        public void Update(User item);

    }

}
