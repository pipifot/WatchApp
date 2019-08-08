using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchAuthApp.Models;
using System.Data.Entity;
using WatchAuthApp.ViewModels;


namespace WatchAuthApp.Managers

{
    public class AppManager
    {
        public ICollection<Movie> GetMovies(string search, string category, int sortBy)
        {
            List<Movie> result;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = db.Movies.AsQueryable();
                if (!String.IsNullOrEmpty(search))
                {
                    query = query.Where(x => x.Title.Contains(search));
                }
                if (!String.IsNullOrEmpty(category))
                {
                    query = query.Where(x => x.Genre == category);
                }
                switch ((SortOptions)sortBy)
                {
                    case SortOptions.Title:
                        query = query.OrderBy(x => x.Title);
                        break;
                    case SortOptions.Year:
                        query = query.OrderBy(x => x.Year);
                        break;
                    default:
                        break;
                }



                result = query.ToList();
            }
            return result;
        }
        public ICollection<Category> GetCategories()
        {
            List<Category> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Categories.ToList();
            }
            return result;
        }
        public ICollection<int> GetFavoriteMovies(string userId)
        {
            ICollection<int> result;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Users.Include(x => x.Movies)
                                 .Where(x=>x.Id==userId)
                                 .First().Movies
                                  .Select(x => x.Id)
                                  .ToList();
            }
            return result;
        }
        public bool ToggleFavoriteMovie(int movieid,string userId)
        {
            bool result;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser user = db.Users.Include(x => x.Movies)
                                                .Where(x => x.Id == userId).FirstOrDefault();
                Movie movie = user.Movies.Where(x => x.Id == movieid).FirstOrDefault();
                if (movie == null)
                {
                    movie = db.Movies.Find(movieid);
                    user.Movies.Add(movie);
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    user.Movies.Remove(movie);
                    db.SaveChanges();
                    result = false;
                }
            }
            return result;
        }

    }
}