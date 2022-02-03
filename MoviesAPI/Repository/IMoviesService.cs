using System.Collections.Generic;

namespace MoviesAPI.Repository
{
    public interface IMoviesService
    {
        public List<Movie> GetAllMovies();
        public Movie GetMovieById(int id);
        public int AddMovie(Movie movie);
        public void UpdateMovie(int movieId, Movie movie);
        public void DeleteMovie(int id);
    }
}