using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
    }
}
