using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public int IdProduit { get; set; }

        public DateTime Date { get; set; }

        public DateTime DatePaiement { get; set; }

        public int QuanteStock { get; set; }

        public DateTime DateDispo { get; set; }

        public double Pu { get; set; }

        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }
    }
}
