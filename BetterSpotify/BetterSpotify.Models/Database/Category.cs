using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetterSpotify.Models.Database
{
    [Table("TbCategory")]
    public class Category
    {
        [Key]public int IdCategory { get; set; }
        [Column(TypeName = "Varchar(50)")] public string Name { get; set; } = null!;
        [Column(TypeName = "Varchar(6)")] public string ColorHex { get; set; } = null!;
        [Column(TypeName = "Varchar(50)")] public string? ImageFile { get; set; }

        public virtual IEnumerable<Song> Songs { get; set; } = null!;
    }
}
