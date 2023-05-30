using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Api.Interfaces
{
    public interface UserInterface
    {
        [HttpGet]
        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, string? orderBy, string[]? country);

        [HttpGet]
        public IActionResult Verify(string Username, string passEnc);
    }
}
