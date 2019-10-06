using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Solar_System.Entities
{
    public class Habitant
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must name something.")]
        [MinLength(3, ErrorMessage = "No Galaxy Race has a three letters name.")]
        public string Species { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}
