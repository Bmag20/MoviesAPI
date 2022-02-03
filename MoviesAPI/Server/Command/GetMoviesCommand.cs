using System;
using System.Text.Json;
using MoviesAPI.Controller;
using MoviesAPI.Exceptions;

namespace MoviesAPI.Server.Command
{
    public class GetMoviesCommand : ICommand
    {
        private readonly MoviesController _controller;

        public GetMoviesCommand(MoviesController controller)
        {
            _controller = controller;
        }

        public Response Execute(Request request)
        {
            if (request.Url == "movies")
            {
                var movies = _controller.GetAllMovies();
                return new Response(200, JsonSerializer.Serialize(movies));
            }

            try
            {
                var movieId = int.Parse(request.segments[2]);
                var movie = _controller.GetMovieById(movieId);
                return new Response(200, JsonSerializer.Serialize(movie));
            }
            catch (FormatException e)
            {
                return new Response(400, "Bad Request - movie id is not a number");
            }
            catch(MovieNotFoundException e)
            {
                return new Response(400, e.Message);
            }
        }
    }
}