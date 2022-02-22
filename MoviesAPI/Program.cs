using System.Net;
using MoviesAPI.Controller;
using MoviesAPI.Repository;

namespace MoviesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://*:5001/");
            // MoviesRepository moviesRepository = new MoviesRepository();
            // var moviesRepository = new DapperService("Data Source=Movies.SQLite");
             var moviesRepository = new PostgreSqlDapperService("User ID=postgres;Password=postgres;Host=127.0.0.1;Port=5432;Database=postgres;");
            Server.Server server = new Server.Server(httpListener, moviesRepository);
            server.Start();
        }
    }
}