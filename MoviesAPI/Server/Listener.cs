using System;
using System.Net;
using MoviesAPI.Controller;
using MoviesAPI.Repository;

namespace MoviesAPI.Server
{
    public class Server
    {
        private readonly HttpListener _listener;
        private HttpListenerContext _context;
        private readonly IMoviesService _movieService;

        public Server(HttpListener httpListener, IMoviesService movieService)
        {
            _listener = httpListener;
            _movieService = movieService;
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Listener started, waiting for requests");
            Console.WriteLine("App is running" );
            while (true)
            {
                _context = _listener.GetContext();
                // var request = _context.Request;
                var request = GetRequest();
                Router router = new Router(request, _movieService);
                Response response = router.Route();
                SetResponse(response);
            }
        }

        private Request GetRequest()
        {
            HttpListenerRequest httpRequest = _context.Request;
            var method = httpRequest.HttpMethod;
            var url = httpRequest.Url.AbsolutePath;
            System.IO.Stream body = httpRequest.InputStream;
            System.Text.Encoding encoding = httpRequest.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            string bodyContent = reader.ReadToEnd();
            body.Close();
            reader.Close();
            return new Request(method, url, bodyContent);
        }

        private void SetResponse(Response response)
        {
            HttpListenerResponse httpResponse = _context.Response;
            httpResponse.StatusCode = (int)response.StatusCode;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(response.Body);
            httpResponse.ContentLength64 = buffer.Length;
            System.IO.Stream output = httpResponse.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}