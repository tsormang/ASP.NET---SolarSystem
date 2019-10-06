using Super_Solar_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Super_Solar_System.Web.ViewModels
{
    public class PlanetViewModel
    {
        public Planet Planet { get; set; }
        public IEnumerable<SelectListItem> Habitants { get; set; }

        private List<int> _selectSpecies;
        public List<int> SelectedSpecies
        {
            get
            {
                if (_selectSpecies == null)
                {
                    _selectSpecies = Planet.Habitants.Select(x => x.Id).ToList();
                }
                return _selectSpecies;
            }
            set
            {
                _selectSpecies = value;
            }
        }


    }
}