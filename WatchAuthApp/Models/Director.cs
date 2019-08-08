﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchAuthApp.Models
{
    public class Director
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}