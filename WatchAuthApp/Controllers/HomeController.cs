using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAuthApp.Models;
using WatchAuthApp.ViewModels;
using WatchAuthApp.Managers;
using Microsoft.AspNet.Identity;

namespace WatchAuthApp.Controllers
{
    public class HomeController : Controller
    {
        private AppManager db = new AppManager();
        [Authorize]
        public ActionResult Index(string search,string category,int sortBy=0)
        {
            ViewBag.Categories = new SelectList(db.GetCategories(),"Name", "Name");
            AppViewModel vm = new AppViewModel()
            {
                Movies = db.GetMovies(search,category,sortBy),
                FavoriteMovies=db.GetFavoriteMovies(User.Identity.GetUserId()),
                Search =search, 
                Category=category,
                SortBy=(SortOptions)sortBy
                
                
            };
            return View(vm);

        }
        [HttpPost]
        [Authorize]
        public JsonResult ToggleFavorite(int movieid)
        {
            bool result=db.ToggleFavoriteMovie(movieid, User.Identity.GetUserId());
            return Json(result);
        }


       
    }
}