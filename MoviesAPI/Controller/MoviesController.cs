using System;
using System.Collections.Generic;
using MoviesAPI.Repository;
using MoviesAPI.Server;

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

        public void HandlePostRequest(Movie movie)
        {
            _movieService.AddMovie(movie);
        }

        public Response HandlePutRequest()
        {
            throw new NotImplementedException();
        }

        public Response HandleDeleteRequest()
        {
            throw new NotImplementedException();
        }
    }
}

    