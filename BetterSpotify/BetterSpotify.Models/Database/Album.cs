using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BetterSpotify.Models.Database
{
    [Table("TbAlbum")]
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }

        //Foreign

        [ForeignKey("User")] public int IdUser { get; set; }
        [ValidateNever] public User User { get; set; } = null!;

        // Parameters

        [Column(TypeName = "Varchar(50)")] public string Title { get; set; } = null!;
        [Column(TypeName = "Varchar(2000)")] public string? Description { get; set; } = null!;
        [Column(TypeName = "Varchar(500)")] public string ImageFile { get; set; } = "Resources/Image/DefaultAlbumPic";

        [Column(TypeName = "Date"), Required] public DateTime DateOfPublish { get; set; } = DateTime.Now;
        [IgnoreDataMember] public string GetDateOfPublish { get { return DateOfPublish.ToShortDateString(); } }

        [ValidateNever]public virtual ICollection<Song> Songs { get; set; } = null!;
    }
}
