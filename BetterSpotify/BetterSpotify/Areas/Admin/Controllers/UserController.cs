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
            return View();
        }

        #region ApiTable

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Users.GetAll();
            return Json(new{data = list});
        }

        #endregion
    }
}
