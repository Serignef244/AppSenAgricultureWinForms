using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class UniteMesure
    {
        [Key]
        public int IdUnite { get; set; }
        [Required,MaxLength(10)]
        public string CodeUnite { get; set; }

        [Required,MaxLength(100)]
        public string LibelleUnite { get; set; }


    }
}
