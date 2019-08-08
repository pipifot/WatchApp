using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAuthApp.Models;

namespace WatchAuthApp.ViewModels
{
    public class MovieViewModel
    {
        public ApplicationUser user {get;set;}
        public Movie Movie { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }
        private List<int> _selectedActors;
        public List<int> SelectedActors
        {
            get
            {
                if (_selectedActors == null)
                {
                    return Movie.Actors.Select(x => x.Id).ToList();

                }
                return _selectedActors;

            } 
            set
            {
                _selectedActors = value;
            }
        }
      

    }
}