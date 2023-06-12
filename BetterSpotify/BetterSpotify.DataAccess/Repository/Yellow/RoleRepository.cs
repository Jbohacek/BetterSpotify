using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository.Green;
using BetterSpotify.Models.Database;
using BetterSpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterSpotify.DataAccess.Repository._IRepository.Yellow;

namespace BetterSpotify.DataAccess.Repository.Yellow
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(Role item)
        {
            _context.TbRoles.Update(item);
        }

        public new void Add(Role item)
        {
            _context.TbRoles.Update(item);
        }
    }
}
