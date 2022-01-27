namespace MoviesAPI.Server
{
    public class Response
    {
        public int StatusCode { get; }
        public string Body { get; }

        public Response(int statusCode, string body)
        {
            StatusCode = statusCode;
            Body = body;
        }
    }
}