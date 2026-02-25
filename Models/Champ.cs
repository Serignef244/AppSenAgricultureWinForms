using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class Champ
    {
        [Key]
        public int IdChamp { get; set; }

        public double SuperficieAgriculteur { get; set; }

        public double LatitudeAgriculteur { get; set; }

        public double LongitudeAgriculteur { get; set; }
    }
}
