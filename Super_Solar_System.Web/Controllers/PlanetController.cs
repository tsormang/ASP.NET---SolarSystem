using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Super_Solar_System.Database;
using Super_Solar_System.Entities;
using Super_Solar_System.Web.Models;
using Super_Solar_System.Web.ViewModels;

namespace Super_Solar_System.Web.Controllers
{
    [Authorize]
    public class PlanetController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private SunContext db = new SunContext();

        [AllowAnonymous]
        // GET: Planet ------------------------------------------------------------------------->>
        public ActionResult Index()
        {
            var movies = db.Planets.Include(m => m.Moons).Include(m => m.Habitants);
            return View(movies);
        }
        // -------------------------------------------------------------------------------------O


        // GET: Planet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return HttpNotFound();
            }
            return View(planet);
        }

        // GET: Movie/Create ------------------------------------------------------------------>>
        public ActionResult Create()
        {
            ViewBag.Moon = new SelectList(db.Moons, "Name", "Name");

            PlanetViewModel plan = new PlanetViewModel()
            {
                Planet = new Planet(),
                Habitants = db.Habitants.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Species
                })
            };
            return View(plan);
        }
        // -------------------------------------------------------------------------------------O


        // POST: Planet/Create ---------------------------------------------------------------->>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanetViewModel plan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Moon = new SelectList(db.Moons, "Name", "Name", plan.Planet.Moons);
                return View(plan);
            }
            foreach (int id in plan.SelectedSpecies)
            {
                Habitant habitant = db.Habitants.Find(id);
                if (habitant != null)
                {
                    plan.Planet.Habitants.Add(habitant);
                }
            }
            db.Planets.Add(plan.Planet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // -------------------------------------------------------------------------------------O


        // GET: Planet/Edit/5 ----------------------------------------------------------------->>
        public ActionResult Edit(int? id)
        {
            Planet planet = db.Planets.Include("Moons")
                                   .Include("Habitants")
                                   // From all those look the ID ...
                                   .Where(x => x.Id == id)
                                   // ... and bring the first Movie
                                   .FirstOrDefault();

            if (planet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Moon = new SelectList(db.Moons, "Name", "Name", planet.Moons);

            PlanetViewModel plan = new PlanetViewModel()
            {
                Planet = planet,
                Habitants = db.Habitants.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Species
                })
            };
            return View(plan);
        }
        // -------------------------------------------------------------------------------------O


        // POST: Planet/Edit/5 ---------------------------------------------------------------->>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlanetViewModel plan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Moon = new SelectList(db.Moons, "Name", "Name", plan.Planet.Moons);

                return View(plan);
            }
            db.Planets.Attach(plan.Planet);
            db.Entry(plan.Planet).Collection("Habitants").Load();
            plan.Planet.Habitants.Clear();
            db.SaveChanges();

            foreach (int id in plan.SelectedSpecies)
            {
                Habitant habitant = db.Habitants.Find(id);
                if (habitant != null)
                {
                    plan.Planet.Habitants.Add(habitant);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // -------------------------------------------------------------------------------------O


        // GET: Planet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return HttpNotFound();
            }
            return View(planet);
        }

        // POST: Planet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planet planet = db.Planets.Find(id);
            db.Planets.Remove(planet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
