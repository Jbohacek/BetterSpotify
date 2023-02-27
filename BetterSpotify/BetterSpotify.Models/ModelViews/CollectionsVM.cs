using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterSpotify.Models.Database;


namespace BetterSpotify.Models.ModelViews
{
    public class CollectionsVM
    {
        public IEnumerable<Category> Categories { get; set; } = null!;
        public IEnumerable<Song> Songs { get; set; } = null!;
        public IEnumerable<Artist> Artists { get;set; } = null!;
        public IEnumerable<Album> Albums { get; set; } = null!;

    }
}
