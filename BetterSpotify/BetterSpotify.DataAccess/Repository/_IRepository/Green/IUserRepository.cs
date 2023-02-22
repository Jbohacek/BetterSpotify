using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository._IRepository.Green
{
    public interface IUserRepository : IRepository<User>
    {
        public void Update(User item);

    }

}
