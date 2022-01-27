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
            MoviesRepository moviesRepository = new MoviesRepository();
            IMovieService movieService = new MovieService(moviesRepository);
            Server.Server server = new Server.Server(httpListener, movieService);
            server.Start();
        }
    }
}