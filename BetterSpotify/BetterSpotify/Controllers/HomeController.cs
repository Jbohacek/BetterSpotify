using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BetterSpotifyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            ViewBag.CountSongs = _unitOfWork.Songs.GetAll().Count();
            ViewBag.CountUsers = _unitOfWork.Users.GetAll().Count();
            ViewBag.CountAlbums = _unitOfWork.Albums.GetAll().Count();
            ViewBag.CountCategories = _unitOfWork.Category.GetAll().Count();
            ViewBag.CountArtist = _unitOfWork.Artist.GetAll().Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}