using Microsoft.AspNetCore.Mvc;
using BetterSpotify.Models.Database;
using BetterSpotify.DataAccess.Data;

namespace BetterSpotifyWeb.Controllers
{
    public class LoginControler : Controller
    {
        private ApplicationDbContext _dbContext;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Verify(User user)
        {
            var qery = from d in _dbContext.TbUsers
                       where d.IdUserProfile == user.IdUserProfile && d.Password == user.Password
                       select d;

            if(qery.Count() > 0 )
            {
                return View("LogIn");
            }
            else
            {
                return View("Error");
            }
            return View();  
        }
    }
}
