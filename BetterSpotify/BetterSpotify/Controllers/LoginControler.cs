using Microsoft.AspNetCore.Mvc;
using BetterSpotify.Models.Database;
using BetterSpotify.DataAccess.Data;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

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

        // <form> <form action="/login" method="post">

        [HttpGet("/login")]
        public IActionResult Jakkoli()
        {
            return View("LogInPage");
        }

        [HttpPost("/login")]
        public IActionResult Verify([FromForm] string email, [FromForm] string password)
        {
            var qery = from d in _dbContext.TbUsers
                       where d.Email == email && d.Password == password
                       select d;

            if(qery.Count() > 0 )
            {
                return View("LogInPage");
            }
            else
            {
                return View("Error");
            }
            return View();  
        }
    }
}
