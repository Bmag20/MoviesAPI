using System.Text.Json;
using MoviesAPI.Controller;

namespace MoviesAPI.Server.Command
{
    public class AddMovieCommand : ICommand
    {
        private readonly MoviesController _controller;

        public AddMovieCommand(MoviesController controller)
        {
            _controller = controller;
        }

        public Response Execute(Request request)
        {
            var movieRequest = JsonSerializer.Deserialize<MovieRequest>(request.Body);
            var id = _controller.AddMovie(movieRequest);
            return new Response(201,  $"{id} created");
        }
    }
}