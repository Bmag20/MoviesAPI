using System.Text.Json;
using MoviesAPI.Controller;
using MoviesAPI.Exceptions;

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
            try
            {
                var movieRequest = JsonSerializer.Deserialize<Movie>(request.Body);
                var id = _controller.AddMovie(movieRequest);
                return new Response(201, $"{id} created");
            }
            catch (JsonException e)
            {
                return new Response(400, "Bad request - Body is not valid JSON");
            }
            catch (MovieAlreadyExistsException e)
            {
                return new Response(409, "Conflict - Movie already exists"); 
            }
        }
    }
}