using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;

namespace MoviesAPI.Repository
{
    public class SqLiteDatabase
    {
        private readonly string _connectionString;

        public SqLiteDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(_connectionString);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Movies';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Movies")
            {
                connection.Execute("Drop table Movies");
            }

            connection.Execute("Create Table Movies (" +
                               "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                               "Title VARCHAR(100) NOT NULL);");
            connection.Execute("INSERT INTO Movies (Title)" +
                               "VALUES ('Thor');");            
            connection.Execute("INSERT INTO Movies (Title)" +
                               "VALUES ('Hulk');");
        }
    }
}