using System.Collections.Generic;

namespace MoviesAPI.Repository
{
    public class DataStructureMovieService : IMoviesService
    {
        private readonly MoviesRepository _moviesRepository;

        public DataStructureMovieService(MoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.Movies;
        }

        public Movie GetMovieById(int id)
        {
            return _moviesRepository.Movies.Find(m => m.Id == id);
        }

        public int AddMovie(Movie movie)
        {
            return _moviesRepository.AddMovie(movie);
        }

        public void UpdateMovie(int id, Movie movie)
        {
            var movieToUpdate = GetMovieById(id);
            movieToUpdate.Title = movie.Title;
        }

        public void DeleteMovie(int id)
        {
            _moviesRepository.Movies.Remove(_moviesRepository.Movies.Find(m => m.Id == id));
        }
    }
}