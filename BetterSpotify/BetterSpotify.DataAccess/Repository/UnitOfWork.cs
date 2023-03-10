using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.DataAccess.Repository._IRepository.Green;
using BetterSpotify.DataAccess.Repository.Green;

namespace BetterSpotify.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; private set; }
        public IAlbumRepository Albums { get; private set; }
        public IArtistRepository Artist { get; private set; }
        public ISongRepository Songs { get; private set; }
        public ICategoryRepository Category { get; private set; }

        public bool DataBaseConnected { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Users = new UserRepository(_context);
            Albums = new AlbumRepository(_context);
            Artist = new ArtistRepository(_context);
            Songs = new SongRepository(_context);
            Category = new CategoryRepository(_context);


            DataBaseConnected = db.Database.CanConnect();

        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
