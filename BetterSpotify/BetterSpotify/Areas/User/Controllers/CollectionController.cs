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
            var listusers = _unitOfWork.Users.GetAll();
            var listSongs = _unitOfWork.Songs.GetAll();
            foreach (var VARIABLE in listSongs)
            {
                VARIABLE.User = listusers.FirstOrDefault(x => VARIABLE.IdUser == x.IdUser);
            }
            return View(listSongs);
        }
    }
}
