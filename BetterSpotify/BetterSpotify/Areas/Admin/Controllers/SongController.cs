using BetterSpotify.DataAccess.Repository._IRepository;
using BetterSpotify.Models.Database;
using BetterSpotify.Models.ModelViews;
using BetterSpotify.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using NAudio.Wave;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SongController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SongController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            SongVM vm = new()
            {
                song = new(),
                UserList = _unitOfWork.Users.GetAll().Select(x => new SelectListItem(){Text = x.IdUser + " - " + x.NickName,Value = x.IdUser.ToString()}),
                AlbumList = _unitOfWork.Albums.GetAll().Select(x => new SelectListItem(){Text = x.IdAlbum + " - " + x.Title,Value = x.IdAlbum.ToString()}),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem(){Text = x.IdCategory + " - " + x.Name,Value = x.IdCategory.ToString()})
            };
            if (id == null || id == 0)
            {
                return View(vm);
            }

            var foundsong = _unitOfWork.Songs.GetFirstOrDefault(x => x.IdSong == id);
            vm.song = foundsong;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SongVM item, IFormFileCollection? file)
        {
            if (ModelState.IsValid)
            {
                
                var manager = FileManager.GetInstance();

                var AudioFile = file.FirstOrDefault(x => x.ContentType.Split('/')[0] == "audio");

                var savedPathSong = string.Empty;
                if (AudioFile != null)
                {
                    var categoryname =
                        _unitOfWork.Category.GetFirstOrDefault(x => x.IdCategory == item.song.IdCategory).Name;
                    savedPathSong = manager.SaveFile(AudioFile, _webHostEnvironment.WebRootPath, categoryname);
                    Mp3FileReader reader = new Mp3FileReader(Path.Combine(_webHostEnvironment.WebRootPath,"music\\musicfiles\\" + savedPathSong));
                    item.song.Duration = Convert.ToInt32(reader.TotalTime.TotalSeconds);

                }

                var savedPathImage = string.Empty;
                var ImageFile = file.FirstOrDefault(x => x.ContentType.Split('/')[0] == "image");
                if (ImageFile != null)
                {
                    savedPathImage = manager.SaveFile(ImageFile, _webHostEnvironment.WebRootPath, FileManager.FileCategory.Song);
                }

                

                

                item.song.SongFile = savedPathSong;
                item.song.ImageFile = savedPathImage;


                

                if (item.song.IdSong != 0)
                {
                    _unitOfWork.Songs.Update(item.song);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.Songs.Add(item.song);
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

            var item = _unitOfWork.Songs.GetFirstOrDefault(x => x.IdSong == id);

            if (item == null) return RedirectToAction("Index");

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            //Delete old image!

            //var oldImage = Path.Combine(wwwRootPath, item.ImageFile.TrimStart('\\'));
            //if (System.IO.File.Exists(oldImage))
            //{
            //    System.IO.File.Delete(oldImage); 
            //}

            _unitOfWork.Songs.Remove(item);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Songs.GetAll();
            return Json(new { data = list });
        }

        #endregion
    }
}
