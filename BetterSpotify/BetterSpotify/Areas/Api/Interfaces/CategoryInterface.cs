using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifyWeb.Areas.Api.Interfaces
{
    public interface CategoryInterface
    {
        [HttpGet]
        public IActionResult GetAll(int page, int pageCount, bool order, string? searchText, string? orderBy);

    }
}
