using System.Text.Json.Serialization;

namespace MoviesAPI
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Movie()
        {
        }
        
        public Movie(int id, string title)
        {
            Id = id;
            Title = title;
        }

        [JsonConstructor]
        public Movie(string title)
        {
            Title = title;
        }
    }
}