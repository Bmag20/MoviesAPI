using System.Text.Json;
using System.Text.RegularExpressions;
using MoviesAPI.Controller;
using MoviesAPI.Exceptions;

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
            if (!Regex.IsMatch(request.Url, @"movies/\d+"))
                return new Response(404, "Bad Request - url is not valid");
            try
            {
                if (!int.TryParse(request.segments[2], out int movieId))
                    return new Response(400, "Bad Request - movie id is not a number");
                var movieRequest = JsonSerializer.Deserialize<Movie>(request.Body);
                var updatedMovie = _controller.UpdateMovie(movieId, movieRequest);
                return new Response(200, JsonSerializer.Serialize(updatedMovie));
            }
            catch (JsonException)
            {
                return new Response(400, "Bad request - Body is not valid JSON");
            }
            catch (MovieNotFoundException)
            {
                return new Response(400, "Bad request - Movie id does not exist");
            }
            catch (MovieNameEmptyException)
            {
                return new Response(400, "Bad request - Movie name cannot be empty");
            }
            catch (MovieAlreadyExistsException)
            {
                return new Response(409, "Conflict - Movie already exists");
            }
        }
    }
}