﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchAuthApp.Models
{
    public class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            User = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public bool Watched { get; set; }
        [ForeignKey("Category")]
        public string Genre { get; set; }
        [DisplayName("Director")]
        public int DirectorID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        

        
        public virtual ICollection<ApplicationUser> User { get; set; }
    }
}