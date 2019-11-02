using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Models;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.ViewModels;

namespace V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Data
{
    public class MovieRepository : IRepository
    {
        ApplicationDbContext context = null;
        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool AddActor(Actor actor)
        {
            try
            {
                context.Actors.Add(actor);
                int result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public bool AddMovie(MovieViewModel movieViewModel)
        {
            try
            {
                context.Movies.Add(movieViewModel.Movie);
                foreach (var actor in movieViewModel.Actors)
                {
                    if (actor.Selected)
                    {
                        var existingActor = context.Actors.Find(Convert.ToInt32(actor.Value));
                        existingActor.Movie = movieViewModel.Movie;
                        context.SaveChanges();
                    }
                }
                context.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteActor(Actor actor)
        {
            try
            {

                context.Actors.Remove(actor);
                int result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }


            catch (Exception)
            {

                throw;
            }
        }



        public bool DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool EditActor(Actor actor)
        {
            context.Entry<Actor>(actor).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            int result = context.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public bool EditMovie(MovieViewModel movieViewModel)
        {
            try
            {
                context.Entry<Movie>(movieViewModel.Movie).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (var actor in movieViewModel.Actors)
                {
                    var existingActor = context.Actors.Find(
                            Convert.ToInt32(actor.Value));
                    if (actor.Selected)
                    {
                        
                        existingActor.Movie = movieViewModel.Movie;
                        
                    }
                    else
                    {
                        
                        existingActor.Movie = null;
                    }
                    context.SaveChanges();
                }
                context.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Actor> GetActorByGender(Gender gender)
        {
            throw new NotImplementedException();
        }

        public Actor GetActorById(int actorId)
        {
            try
            {
                return context.Actors.Find(actorId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Actor> GetActors()
        {
            return context.Actors.ToList();
        }

        public IEnumerable<Actor> GetActorsByGender(Gender gender)
        {
            try
            {
                return context.Actors.Where(a => a.Gender == gender);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Actor> GetActorsByMovie(int movieId)
        {
            try
            {
                return context.Actors.Where(a => a.Movie.Id == movieId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Movie GetMovieById(int movieId)
        {
            try
            {
                return context.Movies.Find(movieId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        public IEnumerable<Movie> GetMoviesByActor(int actorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
