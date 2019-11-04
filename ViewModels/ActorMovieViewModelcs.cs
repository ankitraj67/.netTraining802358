using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Models;

namespace V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.ViewModels
{
    public class ActorMovieViewModelcs
    {
        public IEnumerable<Movie> Movies { get; set; }
        public List<SelectListItem> Actors { get; set; }
    }
}
