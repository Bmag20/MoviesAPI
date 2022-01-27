using System.Collections.Generic;

namespace MoviesAPI.Controller
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        int AddMovie(MovieRequest movie);
        public Movie UpdateMovie(int movieId, MovieRequest movie);
        public void DeleteMovie(int id);
    }
}