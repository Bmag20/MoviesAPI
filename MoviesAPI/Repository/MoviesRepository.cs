using System.Collections.Generic;

namespace MoviesAPI.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private List<Movie> Movies { get; }
        private readonly int _counter;
        
        public MoviesRepository()
        {
            Movies = new List<Movie>
            {
                new Movie(++_counter, "Hulk"),
                new Movie(++_counter, "Iron man"),
                new Movie(++_counter, "Thor")
            };
        }

        public MoviesRepository(List<Movie> movies)
        {
            Movies = movies;
        }
        
        public List<Movie> GetAllMovies()
        {
            return Movies;
        }
        
        public Movie GetMovieId(int id)
        {
            return Movies.Find(m => m.Id == id);
        }
        
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }
        
        public void UpdateMovie(Movie movie)
        {
            var movieToUpdate = GetMovieId(movie.Id);
            movieToUpdate.Title = movie.Title;
        }

        public void DeleteMovie(int id)
        {
            Movies.Remove(Movies.Find(m => m.Id == id));
        }
    }
}