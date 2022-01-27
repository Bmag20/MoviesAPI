using System;
using System.Collections.Generic;
using System.Net;
using MoviesAPI.Controller;
using MoviesAPI.Repository;
using MoviesAPI.Server;

namespace MoviesAPI
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _repository;

        public MovieService(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public string ProcessRequest(Request request)
        {
            Console.WriteLine("Processing request: " +request.Method + " " + request.Url);
            if (request.Method == "GET")
            {
                var movies = _repository.GetAllMovies();
                var moviesString = "";
                foreach (var movie in movies)
                {
                    moviesString += movie.Title + ",";
                }
                moviesString.Trim(',');
                return moviesString;
            }

            return "Method not supported";
        }

        public List<Movie> GetAllMovies()
        {
            return _repository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _repository.GetMovieId(id);
        }

        public void AddMovie(Movie movie)
        {
            _repository.AddMovie(movie);
        }
    }
}