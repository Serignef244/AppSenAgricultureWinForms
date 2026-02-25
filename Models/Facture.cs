using System;
using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class Facture
    {
        [Key]
        public int IdFacture { get; set; }

        [Required, MaxLength(80)]
        public string NumeroFacture { get; set; }

        [Required]
        public DateTime DateFacture { get; set; } = DateTime.Now;

        [Required]
        public double MontantTotal { get; set; }
    }
}
