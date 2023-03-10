using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.User.Controllers
{
    [Area("User")]
    public class CollectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectionController(IUnitOfWork work)
        {
            _unitOfWork = work;
        }

        public IActionResult Index()
        {
            var listSongs = _unitOfWork.Songs.GetAll("Category,User");

            return View(listSongs);
        }
    }
}
