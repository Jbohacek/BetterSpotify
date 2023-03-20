using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterSpotify.Models.Database;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BetterSpotify.Models.ModelViews
{
    public class SongVM
    {
        public Song song { get; set; }
        [ValidateNever] public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever] public IEnumerable<SelectListItem> UserList { get; set; }
        [ValidateNever] public IEnumerable<SelectListItem> AlbumList { get; set; }
    }
}
