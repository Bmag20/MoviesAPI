using System.Collections.Generic;

namespace MoviesAPI.Controller
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void AddMovie(Movie movie);
    }
}