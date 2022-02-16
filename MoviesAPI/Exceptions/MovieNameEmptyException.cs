using System;

namespace MoviesAPI.Exceptions
{
    public class MovieNameEmptyException : Exception
    {
        public MovieNameEmptyException() : base("Movie name is empty!") {}
    }
}