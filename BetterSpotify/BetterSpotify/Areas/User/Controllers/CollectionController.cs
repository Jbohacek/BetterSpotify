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

            //var listusers = _unitOfWork.Users.GetAll();

            //var listcategory = _unitOfWork.Category.GetAll();

            //foreach (var VARIABLE in listSongs)
            //{
            //    VARIABLE.User = listusers.FirstOrDefault(x => VARIABLE.IdUser == x.IdUser);
            //    VARIABLE.Category = listcategory.FirstOrDefault(x => VARIABLE.IdCategory == x.IdCategory);
            //}

            //_unitOfWork.Save();



            return View(listSongs);
        }
    }
}
