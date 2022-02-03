using System;

namespace MoviesAPI.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException() : base("Movie Id does not exist") {}

    }
}