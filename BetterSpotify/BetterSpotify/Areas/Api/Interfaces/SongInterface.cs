using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Api.Interfaces
{
    public interface SongInterface
    {
        [HttpGet]
        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, int[]? catId);

        

    }
}
