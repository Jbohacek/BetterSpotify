using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models.Database;
using BetterSpotify.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlbumController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public AlbumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            AlbumVM vm = new AlbumVM()
            {
                album = new Album(),
                ListUsers = _unitOfWork.Users.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.IdUser + " " + x.NickName,
                    Value = x.IdUser.ToString()
                })
            };


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BetterSpotify.Models.Database.Album item, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Albums.Add(item);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        #region ApiTable

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Albums.GetAll();
            return Json(new { data = list });
        }

        #endregion
    }
}
