using Super_Solar_System.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Super_Solar_System.Web.Controllers
{
    public class newPlanetController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", new newPlanet());
        }

        [HttpPost]
        public ActionResult Save(newPlanet planet, HttpPostedFileBase image)
        {
            if (image != null)
            {
                image.SaveAs(Server.MapPath("~/Images/" + image.FileName));
                planet.Image = image.FileName;
            }
            ViewBag.planet = planet;
            return View("Success");
        }
    }
}