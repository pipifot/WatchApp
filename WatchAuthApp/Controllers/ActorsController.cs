using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAuthApp.Managers;
using WatchAuthApp.Models;

namespace WatchAuthApp.Controllers
{

    public class ActorsController : Controller
    {
        // GET: Actors
        private DbManager db = new DbManager();
        // GET: Actor
        public ActionResult Index()
        {
            var actors = db.GetActors();
            return View(actors);
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            db.AddActor(actor);
            
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id)
        {
            var actor = db.GetwithId(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            db.EditActor(actor);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int id)
        {
            Actor actor = db.GetwithId(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]

        public ActionResult DeleteConfirmed(int id)
        {
            db.Deleteactor(id);
            

            return RedirectToAction("Index");
        }
    }
}