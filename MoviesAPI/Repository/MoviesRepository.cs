using System.Collections.Generic;

namespace MoviesAPI.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private List<Movie> Movies { get; }
        private int _counter;
        
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
        
        public Movie GetMovieById(int id)
        {
            return Movies.Find(m => m.Id == id);
        }
        
        public int AddMovie(MovieRequest movie)
        {
            var newMovie = new Movie(++_counter, movie.Title);
            Movies.Add(newMovie);
            return _counter;
        }
        
        public void UpdateMovie(int id, MovieRequest movie)
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