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

        public SongController(IUnitOfWork db)
        {
            _unitOfWork = db;


        }

        //Pozor zacatek https://localhost:44385 se muze lisit

        //https://localhost:44385/Api/Song/GetAll?page=5&pageCount=10&order=true //Funguje

        //https://localhost:44385/Api/Song/GetAll?page=5&pageCount=10&order=true&searchText=Anime&catId=2&catId=3 //Funguje

        //https://localhost:44385/Api/Song/GetAll?page=5&pageCount=10&order=true&searchText=A%20World%20Away // Vraci pisnicku "A World Away"

        //https://localhost:44385/Api/Song/GetAll?page=5&pageCount=10&order=true&catId=2 Vraci pisnicky, ktery maji kategorii 2

        //https://localhost:44385/Api/Song/GetAll?page=5&pageCount=10&order=true&catId=2&catId=3 Vraci pisnicky, ktery maji kategorrii 2 a 3

        //Kolekce se dělat tak, že kolikrát to tam dáš, tolik prvnků tam je

        //https://jsonviewer.stack.hu/ Tahle stranka ti pomuze videt co je v JSON

        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, int[]? catId)
        {
           List<Song> list = _unitOfWork.Songs.GetAll().ToList();

           //Davej si bacha co je null a co není

           if (catId.Length != 0)
           {
               list = list.Where(x => catId.Contains(x.IdCategory)).ToList();

           }

           if (searchText != null)
           {
               list = list.Where(x => x.Title.ToLower().Contains(searchText.ToLower())).ToList();
           }

           

           //foreach (Song song in list)
           //{
           //    if (!catId.Contains(song.IdCategory))
           //    {
           //        list.Remove(song);  
           //    }
           //    else if (song.Title.ToLower() != searchText.ToLower()
           //              && song.Title.Substring(0,searchText.Length).ToLower() != searchText.ToLower()) 
           //    {
           //        list.Remove(song);
           //    }
           //}

           //if (!order)
           //{
           //    list.Reverse();
           //}

           //int selected = page * pageCount;
           //List<Song> returnList = new List<Song>();

           //for (int i = selected - pageCount + 1; i <= selected; i++)
           //{
           //    returnList.Add(list[i]);
           //}
           

           return Json(list);
        }
    }
}
