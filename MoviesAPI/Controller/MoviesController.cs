using System.Collections.Generic;
using System.Linq;
using MoviesAPI.Exceptions;
using MoviesAPI.Repository;

namespace MoviesAPI.Controller
{
    public class MoviesController
    {
        private readonly IMoviesService _movieService;

        public MoviesController(IMoviesService movieService)
        {
            _movieService = movieService;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieService.GetAllMovies();
        }

        public Movie GetMovieById(int movieId)
        {
            ThrowExceptionIfMovieIdDoesNotExist(movieId);
            return _movieService.GetMovieById(movieId);
        }

        private void ThrowExceptionIfMovieIdDoesNotExist(int movieId)
        {
            if (_movieService.GetMovieById(movieId) == null)
            {
                throw new MovieNotFoundException();
            }
        }
        public int AddMovie(Movie movie)
        {
            ThrowExceptionIfMovieNameAlreadyExists(movie.Title);
            return _movieService.AddMovie(movie);
        }
        
        private void ThrowExceptionIfMovieNameAlreadyExists(string movieName)
        {
            if (IsMovieNameExists(movieName))
            {
                throw new MovieAlreadyExistsException();
            }
        }
        private bool IsMovieNameExists(string movieName)
        {
            return GetAllMovies().Any(movie => movie.Title == movieName);
        }

        public Movie UpdateMovie(int movieId, Movie movie)
        {
            ThrowExceptionIfMovieIdDoesNotExist(movieId);
            ThrowExceptionIfMovieNameAlreadyExists(movie.Title);
            _movieService.UpdateMovie(movieId, movie);
            return GetMovieById(movieId);
        }

        public void DeleteMovie(int movieId)
        {
            ThrowExceptionIfMovieIdDoesNotExist(movieId);
            _movieService.DeleteMovie(movieId);
        }
    }
}

    