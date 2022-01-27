using System.Collections.Generic;

namespace MoviesAPI.Repository
{
    public interface IMoviesRepository
    {
        public List<Movie> GetAllMovies();
        public Movie GetMovieById(int id);
        public int AddMovie(MovieRequest movie);
        public void UpdateMovie(int movieId, MovieRequest movie);
        public void DeleteMovie(int id);
    }
}