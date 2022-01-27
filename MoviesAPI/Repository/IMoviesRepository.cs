using System.Collections.Generic;

namespace MoviesAPI.Repository
{
    public interface IMoviesRepository
    {
        public List<Movie> GetAllMovies();
        public Movie GetMovieId(int id);
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
        public void DeleteMovie(int id);
    }
}