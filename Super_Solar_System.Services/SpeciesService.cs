using Super_Solar_System.Database;
using Super_Solar_System.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Solar_System.Services
{
    public class SpeciesService
    {
        // GET ___________________________________________________________>
        public Habitant GetHabitant(int? id)
        {
            // Connect to Tsirko Database
            using (var context = new SunContext())
            {
                // linq // filters // sortings // order by // group by
                return context.Habitants.Find(id);
            }
        }
        // ===============================================================O

        // Get List with many Habitants ______________________________________>
        public List<Habitant> GetHabitants(string searchString)
        {
            using (var context = new SunContext())
            {
                var Habitants = from a in context.Habitants
                             select a;

                if (!String.IsNullOrEmpty(searchString))
                {
                    Habitants = Habitants.Where(s => s.Species.Contains(searchString));
                }

                return Habitants.ToList();
            }
        }
        // ===============================================================O

        // Save Habitants  ___________________________________________________>
        public void SaveHabitant(Habitant Habitant)
        {
            using (var context = new SunContext())
            {
                context.Habitants.Add(Habitant);
                context.SaveChanges();
            }
        }
        // ===============================================================O

        // Update Habitants ___________________________________________________>
        public void UpdateHabitant(Habitant Habitant)
        {
            using (var context = new SunContext())
            {
                context.Entry(Habitant).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        // ===============================================================O

        // Delete Habitants ___________________________________________________>
        public void DeleteHabitant(Habitant Habitant)
        {
            using (var context = new SunContext())
            {
                context.Entry(Habitant).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        // ===============================================================O
    }
}
