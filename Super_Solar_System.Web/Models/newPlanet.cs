using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Super_Solar_System.Web.Models
{
    public class newPlanet
    {
        public int Id { get; set; }

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

        public string Image { get; set; }

    }
}