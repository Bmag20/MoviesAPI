using System.Collections.Generic;
using MoviesAPI;
using MoviesAPI.Repository;

namespace MoviesAPITests
{
    public class TestRepository : IMoviesService
    {
        private List<Movie> Movies { get; }
        private int _counter;

        public TestRepository(List<Movie> movies)
        {
            Movies = movies;
        }

        public List<Movie> GetAllMovies()
        {
            return Movies;
        }

        public Movie GetMovieById(int id)
        {
            return Movies.Find(m => m.Id == id);
        }

        public int AddMovie(Movie movie)
        {
            var newMovie = new Movie(++_counter, movie.Title);
            Movies.Add(newMovie);
            return _counter;
        }

        public void UpdateMovie(int id, Movie movie)
        {
            var movieToUpdate = GetMovieById(id);
            movieToUpdate.Title = movie.Title;
        }

        public void DeleteMovie(int id)
        {
            Movies.Remove(Movies.Find(m => m.Id == id));
        }
    }
}