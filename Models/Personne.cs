using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Personne
    {
        [Key]
        public int IdPersonne { get; set; }
        [Required, MaxLength(100)]
        public string NomCompletPersonne { get; set; }

        [Required,MaxLength(300)]
        public string AddressePersonne { get; set; }

        [Required,MaxLength(80)]
        public string EmailPersonne { get; set; }

        [Required,MaxLength(20)]
        public string TelPersonne { get; set; }

        [Required, MaxLength(10)]
        public string IdentifiantPersonne { get; set; }


        [Required, MaxLength(300)]
        public string MotDePassePersonne{ get; set; }


    }
}
