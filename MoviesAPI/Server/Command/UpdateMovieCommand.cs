using System.Text.Json;
using System.Text.RegularExpressions;
using MoviesAPI.Controller;

namespace MoviesAPI.Server.Command
{
    public class UpdateMovieCommand : ICommand
    {
        private readonly MoviesController _controller;
        public UpdateMovieCommand(MoviesController moviesController)
        {
            _controller = moviesController;
        }

        public Response Execute(Request request)
        {
            if (Regex.IsMatch(request.Url, @"movies/\d+"))
            {
                if(int.TryParse(request.segments[2], out int movieId))
                {
                    var movieRequest = JsonSerializer.Deserialize<MovieRequest>(request.Body);
                    var updatedMovie = _controller.UpdateMovie(movieId, movieRequest);
                    return new Response(200, JsonSerializer.Serialize(updatedMovie));
                }
                return new Response(400, "Bad Request - movie id is not a number");
            }
            return new Response(400, "Bad Request - url is not valid");
        }
    }
}