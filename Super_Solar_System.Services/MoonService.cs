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
    public class MoonService
    {// GET ___________________________________________________________>
        public Moon GetMoon(int? id)
        {
            // Connect to Tsirko Database
            using (var context = new SunContext())
            {
                // linq // filters // sortings // order by // group by
                return context.Moons.Find(id);
            }
        }
        // ===============================================================O

        // Get List with many Moons ______________________________________>
        public List<Moon> GetMoons(string searchString)
        {
            using (var context = new SunContext())
            {
                var Moons = from a in context.Moons
                                select a;

                if (!String.IsNullOrEmpty(searchString))
                {
                    Moons = Moons.Where(s => s.Name.Contains(searchString));
                }

                return Moons.ToList();
            }
        }
        // ===============================================================O

        // Save Moons  ___________________________________________________>
        public void SaveMoon(Moon Moon)
        {
            using (var context = new SunContext())
            {
                context.Moons.Add(Moon);
                context.SaveChanges();
            }
        }
        // ===============================================================O

        // Update Moons ___________________________________________________>
        public void UpdateMoon(Moon Moon)
        {
            using (var context = new SunContext())
            {
                context.Entry(Moon).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        // ===============================================================O

        // Delete Moons ___________________________________________________>
        public void DeleteMoon(Moon Moon)
        {
            using (var context = new SunContext())
            {
                context.Entry(Moon).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        // ===============================================================O
    }
}
