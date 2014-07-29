using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApplication3.Models;

namespace TestMvcApplication3.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDBContext db = new MoviesDBContext();

        //
        // GET: /Movies/

        public ActionResult Index()
        {
            List<MoviesDB> list = db.movies.ToList();
            Console.WriteLine("list::"+list);
            return View(list);        
        }

        //
        // GET: /Movies/Details/5

        public ActionResult Details(int id = 0)
        {
            MoviesDB moviesdb = db.movies.Find(id);
            if (moviesdb == null)
            {
                return HttpNotFound();
            }
            return View(moviesdb);
        }

        //
        // GET: /Movies/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoviesDB moviesdb)
        {
            if (ModelState.IsValid)
            {
                db.movies.Add(moviesdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moviesdb);
        }

        //
        // GET: /Movies/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MoviesDB moviesdb = db.movies.Find(id);
            if (moviesdb == null)
            {
                return HttpNotFound();
            }
            return View(moviesdb);
        }

        //
        // POST: /Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoviesDB moviesdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviesdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moviesdb);
        }

        //
        // GET: /Movies/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MoviesDB moviesdb = db.movies.Find(id);
            if (moviesdb == null)
            {
                return HttpNotFound();
            }
            return View(moviesdb);
        }

        //
        // POST: /Movies/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoviesDB moviesdb = db.movies.Find(id);
            db.movies.Remove(moviesdb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}