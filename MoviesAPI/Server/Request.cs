namespace MoviesAPI.Server
{
    public class Request
    {
        public string Method { get; }
        //header
        public string Url { get; }
        public string Body { get; }
        
        public string[] segments { get; }
        public Request(string method, string url, string body)
        {
            Method = method;
            Url = url.Trim('/');
            segments = url.Split('/');
            Body = body;
        }
    }
}