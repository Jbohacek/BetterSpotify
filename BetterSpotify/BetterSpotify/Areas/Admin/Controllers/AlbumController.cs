using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.AspNetCore.Mvc;

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
