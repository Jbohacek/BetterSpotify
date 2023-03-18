using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models.Database;
using BetterSpotify.Models.ModelViews;
using BetterSpotify.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlbumController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public AlbumController(IUnitOfWork unitOfWork, IWebHostEnvironment we)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = we;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var vm = new AlbumVM()
            {
                album = new Album(),
                ListUsers = _unitOfWork.Users.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.IdUser + " " + x.NickName,
                    Value = x.IdUser.ToString()
                })
            };

            if(id is 0 or null) return View(vm);

            vm.album = _unitOfWork.Albums.GetFirstOrDefault(x => x.IdAlbum == id);


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AlbumVM item, IFormFile? file)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");


            var fileMan = FileManager.GetInstance();
      
            if (file != null && file.ContentType.Contains("image"))
            {
                item.album.ImageFile = fileMan.SaveFile(file, _webHostEnvironment.WebRootPath, FileManager.FileCategory.Album);
                
            }
            else
            {
                RedirectToAction("Index");
            }

            if (item.album.IdAlbum == 0)
            {
                _unitOfWork.Albums.Add(item.album);
            }
            else
            {
                _unitOfWork.Albums.Update(item.album);
            }
            _unitOfWork.Save();


            return RedirectToAction("Index");
        }

        #region ApiTable


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == null) return RedirectToAction("Index");

            var item = _unitOfWork.Albums.GetFirstOrDefault(x => x.IdAlbum == id);

            if (item == null) return RedirectToAction("Index");

            var wwwRootPath = _webHostEnvironment.WebRootPath;

            //Delete old image!

            //var oldImage = Path.Combine(wwwRootPath, item.ImageFile.TrimStart('\\'));
            //if (System.IO.File.Exists(oldImage))
            //{
            //    System.IO.File.Delete(oldImage); 
            //}

            _unitOfWork.Albums.Remove(item);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Albums.GetAll();
            return Json(new { data = list });
        }

        #endregion
    }
}
