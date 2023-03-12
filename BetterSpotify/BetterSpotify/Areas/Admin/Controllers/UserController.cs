using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
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
        public IActionResult Upsert(BetterSpotify.Models.Database.User item, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRooPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + "ProfilePic";
                    var uploads = Path.Combine(wwwRooPath, @"images/ProfilePics");
                    var extension = Path.GetExtension(file.FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    item.ImageFile = @"\images\ProfilePics\" + filename + extension;

                }

                for (int i = 0; i != 4; i++)
                {
                    item.AddId += new Random().Next(0, 9);
                }

                item.DateOfRegistration = DateTime.Now;
                item.Password = Encription.Encrypt(item.Password);

                _unitOfWork.Users.Add(item);
                _unitOfWork.Save();
            }

            return RedirectToAction("Index");
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
