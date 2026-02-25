using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    [Table("Cultuvateurs")]
    public class Cultivateur : Facilitateur
    {
        [Required, MaxLength(100)]
        [Column("NineaCultuvateur")]
        public string NineaCultivateur { get; set; }

        [Required, MaxLength(100)]
        [Column("RccmCultuvateur")]
        public string RccmCultivateur { get; set; }
    }
}
