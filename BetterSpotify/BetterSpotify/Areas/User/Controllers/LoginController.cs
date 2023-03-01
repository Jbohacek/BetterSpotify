using Microsoft.AspNetCore.Mvc;
using BetterSpotify.Models.Database;
using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models.Database;
using BetterSpotify.Models;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace BetterSpotifyWeb.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }


        //private ApplicationDbContext _dbContext;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BetterSpotify.Models.Database.User user)
        {
            var Finded = _unitOfWork.Users.GetAll().FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (Finded != null) return RedirectToAction("Success");
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        // <form> <form action="/login" method="post">

        //[HttpGet("/login")]
        //public IActionResult Jakkoli()
        //{
        //    return View("LogInPage");
        //}

        //[HttpPost("/login")]
        //public IActionResult Verify([FromForm] string email, [FromForm] string password)
        //{
        //    var qery = from d in _unitOfWork.Users.GetAll()
        //               where d.Email == email && d.Password == password
        //               select d;

        //    ENCRYPT

        //   var query = _unitOfWork.Users.GetAll()
        //       .FirstOrDefault(x => x.Email == email && x.Password == password);


        //    if (query != null)
        //    {
        //        return View("LogInPage");
        //    }
        //    else
        //    {
        //        return View("Error");
        //    }
        //    return View();
        //}
    }
}
