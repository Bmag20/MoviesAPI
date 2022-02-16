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
            httpListener.Prefixes.Add("http://localhost:5001/");
            // MoviesRepository moviesRepository = new MoviesRepository();
             var moviesRepository = new DapperService("Data Source=Movies.SQLite");
            Server.Server server = new Server.Server(httpListener, moviesRepository);
            server.Start();
        }
    }
}