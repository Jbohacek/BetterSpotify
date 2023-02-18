using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetterSpotify.Models.Database
{
    [Table("TbSong")]
    public class Song
    {
        [Key]
        public int IdSong { get; set; }

        [ForeignKey("Album")]
        public int? IdAlbum { get; set; }

        public Album? Album { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        public User User { get; set; } = null!;

        [ForeignKey("Category")] public int IdCategory { get; set; }
        public Category Category { get; set; } = null!;


        [Column(TypeName = "Varchar(50)")] public string Title { get; set; } = null!;
        [Column(TypeName = "Int")] public int? DiscNo { get; set; }     // vůbec nevim co znamená: na kolikátem disku se písnička nachází 
        [Column(TypeName = "Int")] public int? TrackNo { get; set; }
        [Column(TypeName = "Int")] public int Duration { get; set; } = 0!;
        [Column(TypeName = "Varchar(50)")] public string ImageFile { get; set; } = "Resources/Image/DefaultAlbumPic";

        [Column(TypeName = "Date")] public DateTime DateOfRelease { get; set; }



    }
}
