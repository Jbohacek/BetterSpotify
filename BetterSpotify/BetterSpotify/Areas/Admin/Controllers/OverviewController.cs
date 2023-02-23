using BetterSpotify.DataAccess.Repository;
using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OverviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OverviewController(IUnitOfWork work)
        {
            _unitOfWork = work;
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
    }
}
