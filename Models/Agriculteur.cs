using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Agriculteur : Personne
    {
        [Required, MaxLength(200)]
        public string ExploitationAgriculteur { get; set; }

        [Required, MaxLength(200)]
        public string LocalisationAgriculteur { get;set; }
        
        public double SuperficieAgriculteur { get; set; }

        [Required, MaxLength(80)]
        public string TypeAgriculteur { get;  set; }

        [ Required, MaxLength(80)]
        public string RegionAgriculteur { get; set; }

        [Required, MaxLength(80)]
        public string DepartementAgriculteur { get; set; }

        [Required, MaxLength(80)]
        public string CommuneAgriculteur { get; set; } 

        [Required, MaxLength(80)]
        public string VilleVillageAgriculteur { get; set; } 

        public virtual ICollection<Produit> Produits { get; set; }


    }
}
