using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAuthApp.Models;
using WatchAuthApp.Managers;

namespace WatchAuthApp.Controllers
{
    public class RestController : Controller
    {
        private DbManager db = new DbManager();
        [HttpGet] // gia olous tous actors
        public JsonResult Actors()
        {
            var actors = db.GetActors();
            var result = actors.Select(x => new
            {
                Id = x.Id,
                Age = x.Age,
                Name = x.Name
            });
            return Json(actors, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Actor(int id)
        {
            Actor actor = db.GetwithId(id);
            var result = new
            {
                Id = actor.Id,
                Name = actor.Name,
                Age = actor.Age
            };
            return Json(actor, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Actor(Actor actor)
        {
            db.EditActor(actor);
            return Json(actor);
        }
        [HttpPut]
        [ActionName("Actor")]
        public JsonResult AddActor(Actor actor)
        {
            db.AddActor(actor);
            return Json(actor);
        }
        [HttpDelete]
        [ActionName("Actor")]
        public JsonResult DeleteActor(int id)
        { 
            db.Deleteactor(id);
            return Json(true);
        }
    }
}