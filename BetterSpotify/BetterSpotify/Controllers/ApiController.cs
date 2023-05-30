using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
