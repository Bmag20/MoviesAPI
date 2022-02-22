using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using Npgsql;

namespace MoviesAPI.Controller
{
    public class PostgreSqlDapperService : IMoviesService

    {
        private readonly string _connectionString;
    private int counter = 2;

    public PostgreSqlDapperService(string connectionString)
    {
        _connectionString = connectionString;
    }

    
    public List<Movie> GetAllMovies()
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return connection.Query<Movie>("SELECT Id, Title FROM Movies;").ToList();

    }
    public Movie GetMovieById(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return connection.Query<Movie>("SELECT Id, Title FROM Movies;").FirstOrDefault(x => x.Id == id);
    }

    public int AddMovie(Movie movie)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Query<Movie>($"INSERT INTO Movies (Title) VALUES ('{movie.Title}');");
        return connection.Query<Movie>($"Select Id from Movies WHERE Title = '{movie.Title}';").FirstOrDefault().Id;
    }

    public void UpdateMovie(int movieId, Movie movie)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        connection.Query<Movie>($"UPDATE Movies SET Title = '{movie.Title}' WHERE Id = {movieId};");

    }

    public void DeleteMovie(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        connection.Query<Movie>($"Delete from Movies WHERE Id = {id};");

    }
    }
}