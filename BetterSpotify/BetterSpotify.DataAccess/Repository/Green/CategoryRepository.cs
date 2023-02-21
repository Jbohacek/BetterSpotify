using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository.Green;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.Green
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(Category item)
        {
            _context.TbCategories.Update(item);
        }
    }
}
