using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Client : Personne
    {
        [Required, MaxLength(100)]
        [Column("Professiontclient")]
        public string ProfessionClient { get; set; }

        [MaxLength(300)]
        public string MotDePasseHash { get; set; }

        public bool DoitChangerMotDePasse { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
