using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAuthApp.Managers;
using WatchAuthApp.Models;

namespace WatchAuthApp.Controllers
{
    public class DirectorsController : Controller
    {
        private DbManager db = new DbManager();
        // GET: Directors
        public ActionResult Index()
        {
            var directors = db.GetDirectors();
            return View(directors);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }
            db.AddDirector(director);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var director = db.GetDirectorsById(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }
            db.EditDirector(director);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var director = db.GetDirectorsById(id);
            return View(director);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Director director)
        {
            db.DeleteDirector(director);
            return RedirectToAction("Index");
        }
    }
}