using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    public class DetailsCommande
    {
        [Key]
        public int IdDetailsCommande { get; set; }

        public int IdCommande { get; set; }

        public int IdProduit { get; set; }

        public double Quantite { get; set; }

        public double PrixUnitaire { get; set; }

        [ForeignKey("IdCommande")]
        public virtual Commande Commande { get; set; }

        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }
    }
}
