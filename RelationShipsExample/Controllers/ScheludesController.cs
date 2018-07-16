using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RelationShipsExample.Models;

namespace RelationShipsExample.Controllers
{
    public class ScheludesController : Controller
    {
        private SmartCinetEntities db = new SmartCinetEntities();

        // GET: Scheludes
        public ActionResult Index()
        {
            var schelude = db.Schelude.Include(s => s.Cinema).Include(s => s.Day).Include(s => s.Room);
            return View(schelude.ToList());
        }

        // GET: Scheludes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schelude schelude = db.Schelude.Find(id);
            if (schelude == null)
            {
                return HttpNotFound();
            }
            return View(schelude);
        }

        // GET: Scheludes/Create
        public ActionResult Create()
        {
            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name");
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days");
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number");
            return View();
        }

        // POST: Scheludes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheludeId,Shift,Scheludes,Cinema_CinemaId,Day_DayId,Room_RoomId")] Schelude schelude)
        {
            if (ModelState.IsValid)
            {
                db.Schelude.Add(schelude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name", schelude.Cinema_CinemaId);
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days", schelude.Day_DayId);
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number", schelude.Room_RoomId);
            return View(schelude);
        }

        // GET: Scheludes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schelude schelude = db.Schelude.Find(id);
            if (schelude == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name", schelude.Cinema_CinemaId);
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days", schelude.Day_DayId);
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number", schelude.Room_RoomId);
            return View(schelude);
        }

        // POST: Scheludes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheludeId,Shift,Scheludes,Cinema_CinemaId,Day_DayId,Room_RoomId")] Schelude schelude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schelude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name", schelude.Cinema_CinemaId);
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days", schelude.Day_DayId);
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number", schelude.Room_RoomId);
            return View(schelude);
        }

        // GET: Scheludes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schelude schelude = db.Schelude.Find(id);
            if (schelude == null)
            {
                return HttpNotFound();
            }
            return View(schelude);
        }

        // POST: Scheludes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schelude schelude = db.Schelude.Find(id);
            db.Schelude.Remove(schelude);
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
