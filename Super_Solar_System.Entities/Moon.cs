using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Solar_System.Entities
{
    public class Moon
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "You must name something.")]
        [MinLength(2, ErrorMessage = "Moon's Name must be longer")]
        [MaxLength(12, ErrorMessage = "Moon's Name must be shorter")]
        public string Name { get; set; }

        [Display(Name = "Distance from Planet (km)")]
        [Range(1000, 100000, ErrorMessage = "Our Planets can have Moons between 1000Km-100.000Km")]
        public long Distance { get; set; }

        [Required(ErrorMessage = "You must name something.")]
        [Display(Name = "Moon Radius (km)")]
        [Range(100, 10000, ErrorMessage = "Range must be between 100Km-10.000Km")]
        public int Radius { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}
