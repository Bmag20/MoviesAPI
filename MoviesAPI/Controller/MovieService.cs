using System;
using System.Collections.Generic;
using MoviesAPI.Repository;
using MoviesAPI.Server;

namespace MoviesAPI.Controller
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _repository;

        public MovieService(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public List<Movie> GetAllMovies()
        {
            return _repository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _repository.GetMovieById(id);
        }

        public int AddMovie(MovieRequest movie)
        {
            return _repository.AddMovie(movie);
        }

        public Movie UpdateMovie(int movieId, MovieRequest movie)
        {
            _repository.UpdateMovie(movieId, movie);
            return GetMovieById(movieId);
        }

        public void DeleteMovie(int id)
        {
            _repository.DeleteMovie(id);
        }
    }
}