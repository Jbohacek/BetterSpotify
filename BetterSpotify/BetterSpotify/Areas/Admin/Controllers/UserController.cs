using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index(int? id)
        {
            var listusers = _unitOfWork.Users.GetAll();
            var listsong = _unitOfWork.Songs.GetAll();

            foreach (var VARIABLE in listsong)
            {
                listusers.Last().Songs.Add(VARIABLE);
            }
            _unitOfWork.Save();
            return View();
        }
    }
}
