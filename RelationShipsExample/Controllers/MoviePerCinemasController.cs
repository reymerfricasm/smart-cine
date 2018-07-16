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
    public class MoviePerCinemasController : Controller
    {
        private SmartCinetEntities db = new SmartCinetEntities();

        public ActionResult Search(string cinema, string days)
        {
            int key = int.Parse(cinema);
            int day = int.Parse(days);

            var model = db.MoviePerCinema.Where(p => p.Cinema_CinemaId == key && p.Day_DayId == day).ToList();
            ViewBag.Cinema = new SelectList(db.Cinema, "CinemaId", "Name");
            ViewBag.Days = new SelectList(db.Day, "DayId", "Days");

            return View("Index", model);
        }

        // GET: MoviePerCinemas
        public ActionResult Index()
        {

            ViewBag.Cinema = new SelectList(db.Cinema, "CinemaId", "Name");
            ViewBag.Days = new SelectList(db.Day, "DayId", "Days");
            var moviePerCinema = db.MoviePerCinema.Include(m => m.Actor)
                .Include(m => m.Cinema).Include(m => m.Day)
                .Include(m => m.Director).Include(m => m.Movie)
                .Include(m => m.Room).Include(m => m.Schelude);
            return View(moviePerCinema.ToList());
        }

        // GET: MoviePerCinemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePerCinema moviePerCinema = db.MoviePerCinema.Find(id);
            if (moviePerCinema == null)
            {
                return HttpNotFound();
            }
            return View(moviePerCinema);
        }

        // GET: MoviePerCinemas/Create
        public ActionResult Create()
        {
            ViewBag.Actor_ActorId = new SelectList(db.Actor, "ActorId", "Name");
            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name");
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days");
            ViewBag.Director_DirectorId = new SelectList(db.Director, "DirectorId", "Name");
            ViewBag.Movie_MovieId = new SelectList(db.Movie, "MovieId", "Name");
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number");
            ViewBag.Schelude_ScheludeId = new SelectList(db.Schelude, "ScheludeId", "Scheludes");
            return View();
        }

        // POST: MoviePerCinemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoviePerCinemaId,Actor_ActorId,Cinema_CinemaId,Room_RoomId,Day_DayId,Schelude_ScheludeId,Director_DirectorId,Movie_MovieId")] MoviePerCinema moviePerCinema)
        {
            if (ModelState.IsValid)
            {
                db.MoviePerCinema.Add(moviePerCinema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Actor_ActorId = new SelectList(db.Actor, "ActorId", "Name", moviePerCinema.Actor_ActorId);
            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name", moviePerCinema.Cinema_CinemaId);
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days", moviePerCinema.Day_DayId);
            ViewBag.Director_DirectorId = new SelectList(db.Director, "DirectorId", "Name", moviePerCinema.Director_DirectorId);
            ViewBag.Movie_MovieId = new SelectList(db.Movie, "MovieId", "Name", moviePerCinema.Movie_MovieId);
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number", moviePerCinema.Room_RoomId);
            ViewBag.Schelude_ScheludeId = new SelectList(db.Schelude, "ScheludeId", "Scheludes", moviePerCinema.Schelude_ScheludeId);
            return View(moviePerCinema);
        }

        // GET: MoviePerCinemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePerCinema moviePerCinema = db.MoviePerCinema.Find(id);
            if (moviePerCinema == null)
            {
                return HttpNotFound();
            }
            ViewBag.Actor_ActorId = new SelectList(db.Actor, "ActorId", "Name", moviePerCinema.Actor_ActorId);
            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name", moviePerCinema.Cinema_CinemaId);
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days", moviePerCinema.Day_DayId);
            ViewBag.Director_DirectorId = new SelectList(db.Director, "DirectorId", "Name", moviePerCinema.Director_DirectorId);
            ViewBag.Movie_MovieId = new SelectList(db.Movie, "MovieId", "Name", moviePerCinema.Movie_MovieId);
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number", moviePerCinema.Room_RoomId);
            ViewBag.Schelude_ScheludeId = new SelectList(db.Schelude, "ScheludeId", "Scheludes", moviePerCinema.Schelude_ScheludeId);
            return View(moviePerCinema);
        }

        // POST: MoviePerCinemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoviePerCinemaId,Actor_ActorId,Cinema_CinemaId,Room_RoomId,Day_DayId,Schelude_ScheludeId,Director_DirectorId,Movie_MovieId")] MoviePerCinema moviePerCinema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviePerCinema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Actor_ActorId = new SelectList(db.Actor, "ActorId", "Name", moviePerCinema.Actor_ActorId);
            ViewBag.Cinema_CinemaId = new SelectList(db.Cinema, "CinemaId", "Name", moviePerCinema.Cinema_CinemaId);
            ViewBag.Day_DayId = new SelectList(db.Day, "DayId", "Days", moviePerCinema.Day_DayId);
            ViewBag.Director_DirectorId = new SelectList(db.Director, "DirectorId", "Name", moviePerCinema.Director_DirectorId);
            ViewBag.Movie_MovieId = new SelectList(db.Movie, "MovieId", "Name", moviePerCinema.Movie_MovieId);
            ViewBag.Room_RoomId = new SelectList(db.Room, "RoomId", "Number", moviePerCinema.Room_RoomId);
            ViewBag.Schelude_ScheludeId = new SelectList(db.Schelude, "ScheludeId", "Scheludes", moviePerCinema.Schelude_ScheludeId);
            return View(moviePerCinema);
        }

        // GET: MoviePerCinemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePerCinema moviePerCinema = db.MoviePerCinema.Find(id);
            if (moviePerCinema == null)
            {
                return HttpNotFound();
            }
            return View(moviePerCinema);
        }

        // POST: MoviePerCinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoviePerCinema moviePerCinema = db.MoviePerCinema.Find(id);
            db.MoviePerCinema.Remove(moviePerCinema);
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
