using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAuthApp.Managers;
using WatchAuthApp.Models;
using WatchAuthApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WatchAuthApp.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private DbManager db = new DbManager();
        // GET: Movies
        [AllowAnonymous]

        public ActionResult Index()
        {
            var movies = db.GetMovies();
            return View(movies);
        }
        
        public ActionResult Create()
        {
            ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name");
            var categories = db.GetCategories();
            ViewBag.Genre = new SelectList(categories, "Name", "Name");
            MovieViewModel vm = new MovieViewModel()
            {
                Movie = new Movie(),
                Actors = db.GetActors().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })

            };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var directors = db.GetDirectors().AsEnumerable();
                ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name", vm.Movie.DirectorID);
                var categories = db.GetCategories();
                ViewBag.Genre = new SelectList(categories, "Name", "Name", vm.Movie.Genre);
                return View(vm);
            }
            db.AddMovie(vm.Movie, vm.SelectedActors);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var movie = db.GetMovieFull(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var directors = db.GetDirectors().AsEnumerable();
            ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name", movie.DirectorID);
            var categories = db.GetCategories();
            ViewBag.Genre = new SelectList(categories, "Name", "Name", movie.Genre);
            MovieViewModel vm = new MovieViewModel()
            {
                Movie = movie,
                Actors = db.GetActors().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name

                })

            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DirectorId = new SelectList(db.GetDirectors(), "Id", "Name", vm.Movie.DirectorID);
                ViewBag.Genre = new SelectList(db.GetCategories(), "Name", "Name", vm.Movie.Genre);

                ; return View(vm);
            }
            db.EditMovie(vm.Movie, vm.SelectedActors);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var movie = db.GetMovieFull(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           
            db.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}