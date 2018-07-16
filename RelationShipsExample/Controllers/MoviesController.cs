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
    public class MoviesController : Controller
    {
        private SmartCinetEntities db = new SmartCinetEntities();

        // GET: Movies
        public ActionResult Index()
        {
            var movie = db.Movie.Include(m => m.Classification).Include(m => m.Genre).Include(m => m.Studio);
            return View(movie.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.Classification_ClassificationId = new SelectList(db.Classification, "ClassificationId", "Audience");
            ViewBag.Genre_GenreId = new SelectList(db.Genre, "GenreId", "Type");
            ViewBag.Studio_StudioId = new SelectList(db.Studio, "StudioId", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Name,Year,Time,Status,Classification_ClassificationId,Genre_GenreId,Studio_StudioId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movie.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Classification_ClassificationId = new SelectList(db.Classification, "ClassificationId", "Audience", movie.Classification_ClassificationId);
            ViewBag.Genre_GenreId = new SelectList(db.Genre, "GenreId", "Type", movie.Genre_GenreId);
            ViewBag.Studio_StudioId = new SelectList(db.Studio, "StudioId", "Name", movie.Studio_StudioId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classification_ClassificationId = new SelectList(db.Classification, "ClassificationId", "Audience", movie.Classification_ClassificationId);
            ViewBag.Genre_GenreId = new SelectList(db.Genre, "GenreId", "Type", movie.Genre_GenreId);
            ViewBag.Studio_StudioId = new SelectList(db.Studio, "StudioId", "Name", movie.Studio_StudioId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Name,Year,Time,Status,Classification_ClassificationId,Genre_GenreId,Studio_StudioId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classification_ClassificationId = new SelectList(db.Classification, "ClassificationId", "Audience", movie.Classification_ClassificationId);
            ViewBag.Genre_GenreId = new SelectList(db.Genre, "GenreId", "Type", movie.Genre_GenreId);
            ViewBag.Studio_StudioId = new SelectList(db.Studio, "StudioId", "Name", movie.Studio_StudioId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movie.Find(id);
            db.Movie.Remove(movie);
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
