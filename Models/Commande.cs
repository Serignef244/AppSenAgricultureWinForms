using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    public class Commande
    {
        [Key]
        public int IdCommande { get; set; }

        [Required, MaxLength(30)]
        public string NumeroCommande { get; set; }

        public DateTime? DateModificationCommande { get; set; }

        public DateTime DateCommande { get; set; }

        public bool IsCommande { get; set; } = false;

        [ForeignKey("Client")]
        public int? IdClient { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; }
    }
}
