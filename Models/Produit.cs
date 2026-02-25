using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }

        [Required, MaxLength(100)]
        public string LibelleProduit { get; set; }

        [Required, MaxLength(5000)]
        public string DescriptionProduit { get; set; } 

        public double PrixUnitaireMin { get; set; }

        public double PrixUnitaireMax { get; set; }

        public int IdUniteMesure { get; set; }

        [ForeignKey("IdUniteMesure")]

        public virtual UniteMesure UniteMesure { get; set; }

        //mettre relation entre Produit et Categorie
        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
         
        public virtual Categorie Categorie { get; set; }

        public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; }
    }
}
