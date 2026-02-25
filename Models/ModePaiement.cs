using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class ModePaiement
    {
        [Key]
        public int IdPaiement { get; set; }

        [Required, MaxLength(100)]
        public string Type { get; set; }
    }
}
