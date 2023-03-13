using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SongController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BetterSpotify.Models.Database.Song item, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Songs.Add(item);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }


        #region ApiTable

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Songs.GetAll();
            return Json(new { data = list });
        }

        #endregion
    }
}
