using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BetterSpotify.Models.Database
{
    [Table("tbUsers")]
    public class User
    {
        //Primary

        [Key] public int IdUser { get; set; }

        //Foreign
        [ForeignKey("Role")] public int? IdRole { get; set; }
        [ForeignKey("Artist")] public int? IdArtist { get; set; }
        public Artist? Artist { get; set; }
        public Role? Role { get; set; }
        public int? IdUserProfile { get; set; }
        public int? IdTokenWallet { get; set; }
        //Collections

        [ValidateNever] public virtual ICollection<Album> Albums { get; set; } = null!;
        [ValidateNever]public virtual ICollection<Song> Songs { get; set; } = null!;

        //Parameters
        [Column(TypeName = "Varchar(50)"), Required] public string FirstName { get; set; } = null!;
        [Column(TypeName = "Varchar(50)"), Required] public string LastName { get; set; } = null!;
        [Column(TypeName = "Varchar(20)"), Required] public string NickName { get; set; } = null!;
        [Column(TypeName = "Varchar(50)"), Required] public string Email { get; set; } = null!;
        [Column(TypeName = "Varchar(50)")] public string? Country { get; set; }

        [Column(TypeName = "Varchar(4)"), ValidateNever] public string AddId { get; set; } = null!;
        [Column(TypeName = "Date"), Required, DisplayName("Date of Birth")] public DateTime DateOfBirth { get; set; }
        [IgnoreDataMember] public string GetDateOfBirth => DateOfBirth.ToShortDateString();
        [Column(TypeName = "Date"), Required] public DateTime DateOfRegistration { get; set; } = DateTime.Now;
        [IgnoreDataMember] public string GetDateOfRegistration => DateOfRegistration.ToShortDateString();


        // Encrypt 
        [PasswordPropertyText, Column(TypeName = "Varchar(1000)"), Required] public string Password { get; set; } = null!;


        [Column(TypeName = "Bit"), Required, DisplayName("Active account"), ValidateNever] public bool ActiveAccount { get; set; }
        [Column(TypeName = "Bit"), ValidateNever] public bool Verified { get; set; }

        [Column(TypeName = "Varchar(500)"), DisplayName("Image File")] public string ImageFile { get; set; } = "Resources/Image/DefaultUserPic";

    }
}
