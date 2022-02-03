using Dapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace MoviesAPI.Repository
{
    public class DapperService : IMoviesService

    {
    string connectionString =
        "Data Source=Movies.sqlite";
    private int counter = 2;

    public DapperService()
    {
        CreateDatabase();
    }

    private void CreateDatabase()
    {
        SqLiteDatabase db = new SqLiteDatabase(connectionString);
        db.Setup();
    }
    
    public List<Movie> GetAllMovies()
    {
        using var connection = new SqliteConnection(connectionString);

        return connection.Query<Movie>("SELECT Id, Title FROM Movies;").ToList();

    }
    public Movie GetMovieById(int id)
    {
        using var connection = new SqliteConnection(connectionString);

        return connection.Query<Movie>("SELECT Id, Title FROM Movies;").FirstOrDefault(x => x.Id == id);
    }

    public int AddMovie(Movie movie)
    {
        using var connection = new SqliteConnection(connectionString);
        movie.Id = ++counter;
        connection.ExecuteAsync("INSERT INTO Movies (Id, Title)" +
                                       "VALUES (@Id, @Title);", movie);
        return counter;
    }

    public void UpdateMovie(int movieId, Movie movie)
    {
        using var connection = new SqliteConnection(connectionString);

        connection.Query<Movie>($"UPDATE Movies SET Title = '{movie.Title}' WHERE Id = {movieId};");

    }

    public void DeleteMovie(int id)
    {
        using var connection = new SqliteConnection(connectionString);

        connection.Query<Movie>($"Delete from Movies WHERE Id = {id};");

    }
    }
}