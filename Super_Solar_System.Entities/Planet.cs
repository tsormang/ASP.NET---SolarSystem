using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Solar_System.Entities
{
    public class Planet
    {
        public Planet()
        {
            Habitants = new HashSet<Habitant>();
            Moons = new HashSet<Moon>();
        }

        public int Id { get; set; }

        public string Image { get; set; }


        [Required(ErrorMessage = "You must name something.")]
        [MinLength(4, ErrorMessage = "Planet's Name must be longer")]
        [MaxLength(12, ErrorMessage = "Planet's Name must be shorter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must name something.")]
        [Display(Name = "Distance from Sun (km)")]
        [Range(10000, 10000000000, ErrorMessage = "Our Solar System can have Planets between 10000Km-6.000.000.000Km")]
        public long Distance { get; set; }

        [Required(ErrorMessage = "You must name something.")]
        [Display(Name = "Planet Radius (km)")]
        [Range(1000, 200000, ErrorMessage = "Range must be between 1000Km-200.000Km")]
        public int Radius { get; set; }

        [DisplayName("Moons")]
        public virtual ICollection<Moon> Moons { get; set; }

        [DisplayName("Habitants")]
        public virtual ICollection<Habitant> Habitants { get; set; }
    }
}
