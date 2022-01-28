using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using MoviesAPI.Controller;
using MoviesAPI.Repository;
using MoviesAPI.Server.Command;

namespace MoviesAPI.Server
{
    public class Router
    {
        private readonly Request _request;
        private readonly IMoviesRepository _movieService;
        private ICommand _command;

        public Router(Request request, IMoviesRepository movieService)
        {
            _request = request;
            _movieService = movieService;
        }

        public Response Route()
        {
            Console.WriteLine("Processing " + _request.Method + " " +_request.Url);

            if (_request.Url == "movies" || Regex.IsMatch(_request.Url, @"movies/\d+"))
            {
                _command = CreateCommand(new MoviesController(_movieService));
                return _command.Execute(_request);
            }
            return new Response(404, "Not Found");
        }

        // IControlller??
        private ICommand CreateCommand(MoviesController moviesController)
        {
            return _request.Method switch
            {
                "GET" => new GetMoviesCommand(moviesController),
                "POST" => new AddMovieCommand(moviesController),
                "PUT" => new UpdateMovieCommand(moviesController),
                "DELETE" => new DeleteMovieCommand(moviesController),
                _ => new GetMoviesCommand(moviesController) // todo - throw exception
            };
        }
    }
}