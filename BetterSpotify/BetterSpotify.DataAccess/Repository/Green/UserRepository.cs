using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository.Green;
using BetterSpotify.Models;
using BetterSpotify.Models.Database;

namespace BetterSpotify.DataAccess.Repository.Green
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(User item)
        {
            _context.TbUsers.Update(item);
        }

        public new void Add(User item)
        {
            item.Password = Encription.Encrypt(item.Password);
            _context.TbUsers.Add(item);
        }
    }
}
