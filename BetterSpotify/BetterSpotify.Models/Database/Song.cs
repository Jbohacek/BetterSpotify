using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BetterSpotify.Models.Database
{
    [Table("TbSong")]
    public class Song
    {
        [Key]
        public int IdSong { get; set; }

        [ForeignKey("Album")]
        public int? IdAlbum { get; set; }

        [ValidateNever] public Album? Album { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        [ValidateNever] public User User { get; set; } = null!;

        [ForeignKey("Category")] public int IdCategory { get; set; }
        [ValidateNever] public Category Category { get; set; } = null!;


        [Column(TypeName = "Varchar(50)")] public string Title { get; set; } = null!;
        [Column(TypeName = "Int")] public int? DiscNo { get; set; }     // vůbec nevim co znamená: na kolikátem disku se písnička nachází 
        [Column(TypeName = "Int")] public int? TrackNo { get; set; }
        [Column(TypeName = "Int")] public int Duration { get; set; }
        [Column(TypeName = "Varchar(500)"),DisplayName("Picture")] public string ImageFile { get; set; } = "Resources/Image/DefaultAlbumPic";
        [Column(TypeName = "Varchar(500)")] public string SongFile { get; set; } = "Resources/Image/DefaultUserPic";
        [Column(TypeName = "Bit")] public bool Verified { get; set; } = false;
        [Column(TypeName = "Bit")] public bool NoCopyRight { get; set; } = false;

        [Column(TypeName = "Date"), Required] public DateTime DateOfRelease { get; set; } = DateTime.Now;
        [IgnoreDataMember] public string GetDateOfRelease
        {
            get { return DateOfRelease.ToShortDateString(); }
        }


        public string ToScript()
        {
            var end = @"{name: " + Title + " ,";
            end += "artist: '" + User.NickName+ "',";
            end += "image: '" + ImageFile + "',";
            end += "path: '" + SongFile + "' },";
            return end;
        }
    }
}
