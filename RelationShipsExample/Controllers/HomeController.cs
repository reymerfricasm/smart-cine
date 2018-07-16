using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelationShipsExample.Models;

namespace RelationShipsExample.Controllers
{
    public class HomeController : Controller
    {
        private SmartCinetEntities db = new SmartCinetEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public JsonResult GetLastMovie()
        {
            var jsonResult = db.Movie.Select(m => m.Name).Take(5).ToList();

            return Json(jsonResult, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult GetLastSchelude()
        {
            var jsonResult = db.Schelude.Select(s => s.Day.Days).Take(5).ToList();
            return Json(jsonResult, JsonRequestBehavior.DenyGet);
        }
        //[HttpPost]
        //public JsonResult GetLastRecent()
        //{
        //    var jsonResult = db.Schelude.Select(s => s.Day).Take(5).Last().ToList();
        //    return Json(jsonResult, JsonRequestBehavior.DenyGet);
        //}
    }
}