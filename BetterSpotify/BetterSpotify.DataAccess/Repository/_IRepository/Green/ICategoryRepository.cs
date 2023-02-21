using BetterSpotify.DataAccess.Repository.IRepository;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository._IRepository.Green
{
    public interface ICategory : IRepository<Category>
    {
        public void Update();
    }
}
