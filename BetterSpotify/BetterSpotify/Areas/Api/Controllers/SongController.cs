using BetterSpotifyWeb.Areas.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BetterSpotify.Models.Database;
using BetterSpotify.Models.ModelViews;
using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BetterSpotifyWeb.Areas.Api.Controllers
{
    [Area("Api")]
    public class SongController : Controller, SongInterface
    {
        private  IUnitOfWork _unitOfWork;
        //
        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, int[]? catId)
        {
           List<Song> list = _unitOfWork.Songs.GetAll().ToList();
            
            foreach (Song song in list)
            {
                if (!catId.Contains(song.IdCategory))
                {
                    list.Remove(song);  
                }
                else if (song.Title.ToLower() != searchText.ToLower() && song.Title.Substring(0,searchText.Length).ToLower() != searchText.ToLower()) 
                {
                    list.Remove(song);
                }
            }

            if (!order)
            {
                list.Reverse();
            }

            int selected = page * pageCount;
            List<Song> returnList = new List<Song>();

            for (int i = selected - pageCount + 1; i <= selected; i++)
            {
                returnList.Add(list[i]);
            }
           

            return Json(returnList);
        }
    }
}
