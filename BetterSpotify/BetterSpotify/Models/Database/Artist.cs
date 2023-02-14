using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Resources;

namespace BetterSpotify.Models.Database
{
    [Table("TbArtist")]
    public class Artist
    {
        [Key]
        public int IdArtist { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        public User User { get; set; } = null!;

        [Column(TypeName = "Varchar(50)"), Required] public string FirstName { get; set; } = null!;
        [Column(TypeName = "Varchar(50)"), Required] public string LastName { get; set; } = null!;
        [Column(TypeName = "Varchar(5000)"), Required] public string Description { get; set; } = null!;
        [Column(TypeName = "Varchar(50)"), Required] public string Country { get; set; } = null!;

        [Column(TypeName = "Date"), Required] public DateTime ActiveFrom { get; set; }
        [Column(TypeName = "Date")] public DateTime? ActiveTo { get; set; }

        [Column(TypeName = "Varchar(100)"), Required]
        public string ImageFile { get; set; } = null!;
        [Column(TypeName = "Varchar(200)")] public string? WikiLink { get; set; }
    }
}
