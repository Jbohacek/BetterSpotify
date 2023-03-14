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
        public IActionResult Index()
        {
            return View();
        }


        //get
        public IActionResult Upsert(int? id)
        {
            BetterSpotify.Models.Database.User item = new();

            if (id == null || id == 0) return View(item);

            var FoundItem = _unitOfWork.Users.GetFirstOrDefault(x => x.IdUser == id);

            return View(FoundItem);
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

                    if (item.ImageFile != null)
                    {
                        var oldImagePath = Path.Combine(wwwRooPath, item.ImageFile.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    item.ImageFile = @"\images\ProfilePics\" + filename + extension;

                }

                if (item.IdUser == 0)
                {
                    for (int i = 0; i != 4; i++)
                    {
                        item.AddId += new Random().Next(0, 9);
                    }

                    item.DateOfRegistration = DateTime.Now;
                    item.Password = Encription.Encrypt(item.Password);

                    _unitOfWork.Users.Add(item);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.Users.Update(item);
                    _unitOfWork.Save();
                }

                
            }

            return RedirectToAction("Index");
        }

        #region ApiTable

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == null) return RedirectToAction("Index");

            var item = _unitOfWork.Users.GetFirstOrDefault(x => x.IdUser == id);

            if (item == null) return RedirectToAction("Index");

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var oldImage = Path.Combine(wwwRootPath, item.ImageFile.TrimStart('\\'));
            if (System.IO.File.Exists(oldImage))
            {
                System.IO.File.Delete(oldImage);
            }

            _unitOfWork.Users.Remove(item);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Users.GetAll();
            return Json(new{data = list});
        }

        #endregion
    }
}
