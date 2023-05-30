using BetterSpotifyWeb.Areas.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Api.Controllers
{
    [Area("Api")]
    public class UserController : Controller, UserInterface
    {
        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, string? orderBy, string[]? country)
        {
            return Json("Ahoj");
        }

        public IActionResult Verify(string Username, string passEnc)
        {
            bool Verified = false;

            return Json(Verified);
        }
    }
}
