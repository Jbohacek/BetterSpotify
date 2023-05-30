using BetterSpotifyWeb.Areas.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Api.Controllers
{
    [Area("Api")]
    public class CategoryController : Controller , CategoryInterface
    {
        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, string? orderBy)
        {
            
                
            return Json("Ahoj");
            
        }
    }
}
