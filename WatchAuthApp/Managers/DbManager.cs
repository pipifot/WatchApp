using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchAuthApp.Models;


namespace WatchAuthApp.Managers
{
    public class DbManager
    {
        public ICollection<Actor> GetActors()
        {
            ICollection<Actor> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Actors.ToList();
            }
            return result;
        }
        public void AddActor(Actor actor)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }

        }
        public Actor GetwithId(int id)
        {

            Actor actor;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                actor = db.Actors.Find(id);
            }
            return actor;
        }
        public void EditActor(Actor actor)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Actors.Attach(actor);
                db.Entry(actor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }
        public void Deleteactor(int id)
        {
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Actor actor = db.Actors.Find(id);
                db.Actors.Remove(actor);
                db.SaveChanges();
            }
        }
        public bool DeleteActorBool(int id)
        {
            bool result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Actor actor = db.Actors.Find(id);
                if (actor != null)
                {
                    db.Actors.Remove(actor);
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public ICollection<Director> GetDirectors()
        {
            ICollection<Director> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Directors.ToList();
            }
            return result;
        }
        public void AddDirector(Director director)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Directors.Add(director);
                db.SaveChanges();
            }

        }
        public Director GetDirectorsById(int id)
        {

            Director director;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                director = db.Directors.Find(id);
            }
            return director;
        }
        public void EditDirector(Director director)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Directors.Attach(director);
                db.Entry(director).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }
        public void DeleteDirector(Director director)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Directors.Attach(director);
                db.Directors.Remove(director);
                db.SaveChanges();
            }
        }
        public ICollection<Category> GetCategories()
        {
            ICollection<Category> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Categories.ToList();
            }
            return result;
        }
        public Category GetCategoryPK(string name)
        {
            Category result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Categories.Find(name);

            }
            return result;
        }
        public void AddCategory(Category category)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(string name)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Category category = db.Categories.Find(name);
                db.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public ICollection<Movie> GetMovies()
        {
            ICollection<Movie> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Movies.Include("Category")
                                  .Include("Director")
                                  .Include("Actors")
                                  .ToList();
            }
            return result;
        }
        public void AddMovie(Movie movie, List<int> actorIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                foreach (var id in actorIds)
                {
                    Actor actor = db.Actors.Find(id);
                    if (actor != null)
                    {
                        movie.Actors.Add(actor);

                    }
                }
                db.SaveChanges();
            }
        }
        public Movie GetMovieId(int id)
        {
            Movie result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Movies.Find(id);
            }
            return result;
        }
        public void EditMovie(Movie movie, List<int> actorIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Movies.Attach(movie);

                db.Entry(movie).Collection("Actors").Load();
                movie.Actors.Clear();
                db.SaveChanges();
                foreach (var id in actorIds)
                {

                    Actor actor = db.Actors.Find(id);

                    if (actor != null)
                    {


                        movie.Actors.Add(actor);

                    }
                }
                db.SaveChanges();

                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Movie GetMovieFull(int id)
        {
            Movie result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Movies.Include("Category")
                                  .Include("Director")
                                  .Include("Actors")
                                  .Where(x => x.Id == id).FirstOrDefault();

            }
            return result;
        }
        public void DeleteMovie(int id)
        {
            Movie movie;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                movie = db.Movies.Find(id);
                db.Entry(movie).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        //        public List<Movie> GetFavorites(int userId)
        //        {
        //            List<Movie> result;
        //            using (ApplicationDbContext db = new ApplicationDbContext())
        //            {
        //                result = db..Where(x => x.Id == userId).ToList();
        //            }
        //            return result;
        //        }
    }
}