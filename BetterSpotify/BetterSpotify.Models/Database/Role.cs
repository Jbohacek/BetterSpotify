using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterSpotify.Models.Database
{
    [Table("tbRoles")]
    public class Role
    {
        [Key] public int IdRole { get; set; }

        [Column(TypeName = "Varchar(50)"), Required] public string Name { get; set; } = null!;
        [Column(TypeName = "Varchar(6)"), Required] public string ColorHex { get; set; } = null!;
        [Column(TypeName = "Varchar(10)"), Required] public string Prefix { get; set; } = null!;
    }
}
