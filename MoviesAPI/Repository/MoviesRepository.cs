using System.Collections.Generic;

namespace MoviesAPI.Repository
{
    public class MoviesRepository 
    {
        public List<Movie> Movies { get; }
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

        public int AddMovie(Movie movie)
        {
            var newMovie = new Movie(++_counter, movie.Title);
            Movies.Add(newMovie);
            return _counter;
        }
        

    }
}