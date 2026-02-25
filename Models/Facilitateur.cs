using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Facilitateur: Personne
    {

        [Required,MaxLength(150)] 
        public string OrganisationFacilitateur { get; set; }

    }
}
