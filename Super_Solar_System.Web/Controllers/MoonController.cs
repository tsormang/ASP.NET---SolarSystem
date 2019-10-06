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
    public class MoonController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private MoonService MoonService = new MoonService();

        // GET: Moon -------------------------------------------------------->>
        public ActionResult Index(string searchString)
        {
            return View(MoonService.GetMoons(searchString));
        }
        // ================================================================== O

        // GET: Moon/Details/5 ---------------------------------------------->>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moon moon = MoonService.GetMoon(id);
            if (moon == null)
            {
                return HttpNotFound();
            }
            return View(moon);
        }

        // GET: Moon/Create  ----------------------------------------------->>
        public ActionResult Create()
        {
            return View();
        }
        // ================================================================== O

        // POST: Moon/Create  ----------------------------------------------->>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Distance,Radius")] Moon moon)
        {
            if (ModelState.IsValid)
            {
                MoonService.SaveMoon(moon);
                return RedirectToAction("Index");
            }

            return View(moon);
        }

        // GET: Moon/Edit/5 ------------------------------------------------->>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moon moon = MoonService.GetMoon(id);
            if (moon == null)
            {
                return HttpNotFound();
            }
            return View(moon);
        }

        // POST: Moon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Distance,Radius")] Moon moon)
        {
            if (ModelState.IsValid)
            {
                MoonService.UpdateMoon(moon);
                return RedirectToAction("Index");
            }
            return View(moon);
        }
        // ================================================================== O

        // GET: Moon/Delete/5  ---------------------------------------------->>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moon moon = MoonService.GetMoon(id);
            if (moon == null)
            {
                return HttpNotFound();
            }
            return View(moon);
        }

        // POST: Moon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moon moon = MoonService.GetMoon(id);
            MoonService.DeleteMoon(moon);
            return RedirectToAction("Index");
        }
        // ================================================================== O

    }
}
