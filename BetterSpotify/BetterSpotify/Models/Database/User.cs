using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetterSpotify.Models.Database
{
    [Table("tbUsers")]
    public class User
    {
        //Primary

        [Key] public int IdUser { get; set; }

        //Foreign
        public int? IdRole { get; set; }
        [ForeignKey("Artist")] public int? IdArtist { get; set; }
        public Artist? Artist { get; set; }
        public int? IdUserProfile { get; set; }
        public int? IdTokenWallet { get; set; }
        //Collections

        public ICollection<Album> Albums { get; set; } = null!;

        //Parameters
        [Column(TypeName = "Varchar(50)"), Required] public string FirstName { get; set; } = null!;
        [Column(TypeName = "Varchar(50)"), Required] public string LastName { get; set; } = null!;
        [Column(TypeName = "Varchar(20)"), Required] public string NickName { get; set; } = null!;
        [Column(TypeName = "Varchar(50)"), Required] public string Email { get; set; } = null!;
        [Column(TypeName = "Varchar(50)")] public string? Country { get; set; }

        [Column(TypeName = "Varchar(4)")] public string AddId { get; set; } = null!;
        [Column(TypeName = "Date"), Required] public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "Date"), Required] public DateTime DateOfRegistration { get; set; } = DateTime.Now;


        // Encrypt 
        [PasswordPropertyText, Column(TypeName = "Varchar(100)"), Required] public string Password { get; set; } = null!;


        [Column(TypeName = "Bit"), Required] public bool ActiveAccount { get; set; } = false;
        [Column(TypeName = "Bit")] public bool Verified { get; set; } = false;

        [Column(TypeName = "Varchar(50)")] public string ImageFile { get; set; } = "Resources/Image/DefaultUserPic";

    }
}
