using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using MoviesAPI.Repository;

namespace MoviesAPI.Controller
{
    public class DapperService : IMoviesService

    {
        private readonly string _connectionString;
    private int counter = 2;

    public DapperService(string connectionString)
    {
        this._connectionString = connectionString;
        CreateDatabase();
    }

    private void CreateDatabase()
    {
        SqLiteDatabase db = new SqLiteDatabase(_connectionString);
        db.Setup();
    }
    
    public List<Movie> GetAllMovies()
    {
        using var connection = new SqliteConnection(_connectionString);

        return connection.Query<Movie>("SELECT Id, Title FROM Movies;").ToList();

    }
    public Movie GetMovieById(int id)
    {
        using var connection = new SqliteConnection(_connectionString);

        return connection.Query<Movie>("SELECT Id, Title FROM Movies;").FirstOrDefault(x => x.Id == id);
    }

    public int AddMovie(Movie movie)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.ExecuteAsync("INSERT INTO Movies (Title)" +
                                       "VALUES (@Title);", movie);
        return counter;
    }

    public void UpdateMovie(int movieId, Movie movie)
    {
        using var connection = new SqliteConnection(_connectionString);

        connection.Query<Movie>($"UPDATE Movies SET Title = '{movie.Title}' WHERE Id = {movieId};");

    }

    public void DeleteMovie(int id)
    {
        using var connection = new SqliteConnection(_connectionString);

        connection.Query<Movie>($"Delete from Movies WHERE Id = {id};");

    }
    }
}