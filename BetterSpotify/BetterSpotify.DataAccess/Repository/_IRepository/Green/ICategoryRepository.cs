using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository._IRepository.Green
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Update(Category item);
    }
}
