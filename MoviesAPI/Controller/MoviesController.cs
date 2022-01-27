using System.Collections.Generic;

namespace MoviesAPI.Controller
{
    public class MoviesController
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public List<Movie> HandleGetAllRequest()
        {
            return _movieService.GetAllMovies();
        }

        public Movie HandleGetByIdRequest(int id)
        {
            return _movieService.GetMovieById(id);
        }

        public int HandlePostRequest(MovieRequest movie)
        {
            return _movieService.AddMovie(movie);
        }

        public Movie HandlePutRequest(int movieId, MovieRequest movie)
        {
            return _movieService.UpdateMovie(movieId, movie);
        }

        public void HandleDeleteRequest(int movieId)
        {
            _movieService.DeleteMovie(movieId);
        }
    }
}

    