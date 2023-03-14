using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int? id)
        {
            return View();
        }

        public IActionResult Upsert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BetterSpotify.Models.Database.Category item, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRooPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + "CategoryPics";
                    var uploads = Path.Combine(wwwRooPath, @"images/CategoryPics");
                    var extension = Path.GetExtension(file.FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    item.ImageFile = @"\images\CategoryPics\" + filename + extension;

                }

                _unitOfWork.Category.Add(item);
                _unitOfWork.Save();
            }

            return RedirectToAction("Index");
        }

        #region ApiTable

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Category.GetAll();
            return Json(new { data = list });
        }

        #endregion
    }
}
