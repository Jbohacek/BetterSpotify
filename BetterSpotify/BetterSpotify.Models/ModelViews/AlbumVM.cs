using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterSpotify.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BetterSpotify.Models.ModelViews
{
    public class AlbumVM
    {
        public Album album { get; set; }

        public IEnumerable<SelectListItem> ListUsers { get; set; }

    }
}
