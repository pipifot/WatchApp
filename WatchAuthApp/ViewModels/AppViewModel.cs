using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchAuthApp.Models;

namespace WatchAuthApp.ViewModels
{
    public enum SortOptions
    {
        None,
        Title,
        Year,
        
    }
    public class AppViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<int> FavoriteMovies { get; set; }
        public  SortOptions SortBy { get; set; }
        public string Search { get; set; }
        public string Category { get; set; }

    }
}