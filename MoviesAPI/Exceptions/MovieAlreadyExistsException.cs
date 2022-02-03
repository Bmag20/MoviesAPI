using System;

namespace MoviesAPI.Exceptions
{
    public class MovieAlreadyExistsException : Exception    
    {
        public MovieAlreadyExistsException() : base("Movie already exists!") {}
    }
}