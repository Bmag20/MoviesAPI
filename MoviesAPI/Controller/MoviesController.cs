using System.Collections.Generic;
using MoviesAPI.Repository;

namespace MoviesAPI.Controller
{
    public class MoviesController
    {
        private readonly IMoviesRepository _movieService;

        public MoviesController(IMoviesRepository movieService)
        {
            _movieService = movieService;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieService.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieService.GetMovieById(id);
        }

        public int AddMovie(MovieRequest movie)
        {
            return _movieService.AddMovie(movie);
        }

        public Movie UpdateMovie(int movieId, MovieRequest movie)
        {
            _movieService.UpdateMovie(movieId, movie);
            return GetMovieById(movieId);
        }

        public void DeleteMovie(int movieId)
        {
            _movieService.DeleteMovie(movieId);
        }
    }
}

    