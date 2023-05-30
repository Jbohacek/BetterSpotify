using BetterSpotifyWeb.Areas.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Api.Controllers
{
    [Area("Api")]
    public class SongController : Controller, SongInterface
    {
        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, string? orderBy, int[]? catId)
        {
            return Json("Ahoj");
        }
    }
}
