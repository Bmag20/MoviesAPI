using System.Text.RegularExpressions;
using MoviesAPI.Controller;
using MoviesAPI.Exceptions;

namespace MoviesAPI.Server.Command
{
    public class DeleteMovieCommand : ICommand
    {
        private readonly MoviesController _controller;

        public DeleteMovieCommand(MoviesController controller)
        {
            _controller = controller;
        }

        public Response Execute(Request request)
        {
            if (!Regex.IsMatch(request.Url, @"movies/\d+")) 
                return new Response(404, "Bad Request - url is not valid");
            if (!int.TryParse(request.segments[2], out int movieId))
                return new Response(400, "Bad Request - movie id is not a number");
            try
            {
                _controller.DeleteMovie(movieId);
                return new Response(200, "Movie deleted");
            }
            catch(MovieNotFoundException e)
            {
                return new Response(400, e.Message);
            }
        }
    }
}