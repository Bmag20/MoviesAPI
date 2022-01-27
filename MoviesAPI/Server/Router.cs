using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using MoviesAPI.Controller;

namespace MoviesAPI.Server
{
    public class Router
    {
        private readonly Request _request;
        private readonly IMovieService _movieService;


        public Router(Request request, IMovieService movieService)
        {
            _request = request;
            _movieService = movieService;
        }

        public Response Route()
        {
            Console.WriteLine("Processing " + _request.Method + " " +_request.Url);

            if (_request.Url.Contains("movies"))
            {
                return HandleRequest(new MoviesController(_movieService));
            }
            return new Response(404, "Not Found");
        }

        private Response HandleRequest(MoviesController moviesController)
        {
            Movie movie;
            switch (_request.Method)
            {
                case "GET":
                    if (_request.Url == "movies")
                    {
                        var movies = moviesController.HandleGetAllRequest();
                        return new Response(200, JsonSerializer.Serialize(movies));
                    }
                    if (Regex.IsMatch(_request.Url, @"movies/\d+"))
                    {
                        if(int.TryParse(_request.segments[2], out int movieId))
                        {
                            movie = moviesController.HandleGetByIdRequest(movieId);
                            return new Response(200, JsonSerializer.Serialize(movie));
                        }
                        return new Response(400, "Bad Request - movie id is not a number");
                    }
                    return new Response(400, "Bad request - invalid path");
                case "POST":
                    // todo - validate request body
                    movie = JsonSerializer.Deserialize<Movie>(_request.Body);
                        moviesController.HandlePostRequest(movie);
                        return new Response(201, "Success");
                case "PUT":
                    movie = JsonSerializer.Deserialize<Movie>(_request.Body);
                    //moviesController.HandlePutRequest(movie);
                    return new Response(201, "Success");
                case "DELETE":
                    return moviesController.HandleDeleteRequest();
                default:
                    return new Response(405, "Method Not Allowed");
            }
        }
    }
}