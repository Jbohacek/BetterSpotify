using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository.IRepository;

namespace BetterSpotify.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Users = new UserRepository(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
