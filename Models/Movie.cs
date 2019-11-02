﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Validators;

namespace V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Release")]
        [DateValidator]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Rating Should Be Between 1 to 10")]
        public decimal Rating { get; set; }
        
        public ICollection<Actor> Actors { get; set; }
    }
}
