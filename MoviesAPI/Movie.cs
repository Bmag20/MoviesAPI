namespace MoviesAPI
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Movie(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}