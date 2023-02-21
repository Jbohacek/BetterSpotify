using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository.IRepository;
using BetterSpotify.DataAccess.Repository.IRepository.Green;

namespace BetterSpotify.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; }
        public IAlbumRepository Albums { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Users = new UserRepository(_context);
            Albums = new AlbumRepository(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
