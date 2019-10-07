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
using Super_Solar_System.Services;
using Super_Solar_System.Web.Models;

namespace Super_Solar_System.Web.Controllers
{
    [Authorize]
    public class HabitantController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private SpeciesService SpeciesService = new SpeciesService();

        [AllowAnonymous]
        // GET: Habitant -------------------------------------------------------->>
        public ActionResult Index(string searchString)
        {
            return View(SpeciesService.GetHabitants(searchString));
        }
        // ====================================================================== O

        // GET: Habitant/Details/5 ---------------------------------------------->>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitant habitant = SpeciesService.GetHabitant(id);
            if (habitant == null)
            {
                return HttpNotFound();
            }
            return View(habitant);
        }

        // GET: Habitant/Create ------------------------------------------------->>
        public ActionResult Create()
        {
            return View();
        }
        // ====================================================================== O

        // POST: Habitant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Species")] Habitant habitant)
        {
            if (ModelState.IsValid)
            {
                SpeciesService.SaveHabitant(habitant);
                return RedirectToAction("Index");
            }

            return View(habitant);
        }
        // ====================================================================== O

        // GET: Habitant/Edit/5 ------------------------------------------------->>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitant habitant = SpeciesService.GetHabitant(id);
            if (habitant == null)
            {
                return HttpNotFound();
            }
            return View(habitant);
        }

        // POST: Habitant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Species")] Habitant habitant)
        {
            if (ModelState.IsValid)
            {
                SpeciesService.UpdateHabitant(habitant);
                return RedirectToAction("Index");
            }
            return View(habitant);
        }
        // ====================================================================== O

        // GET: Habitant/Delete/5 ----------------------------------------------->>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitant habitant = SpeciesService.GetHabitant(id);
            if (habitant == null)
            {
                return HttpNotFound();
            }
            return View(habitant);
        }

        // POST: Habitant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Habitant habitant = SpeciesService.GetHabitant(id);
            SpeciesService.DeleteHabitant(habitant);
            return RedirectToAction("Index");
        }
        // ====================================================================== O
    }
}
