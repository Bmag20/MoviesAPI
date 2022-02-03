using System.Collections.Generic;
using MoviesAPI;
using MoviesAPI.Repository;
using MoviesAPI.Server;
using Xunit;

namespace MoviesAPITests
{
    public class RouterTests
    {
        private static readonly List<Movie> Movies = new(){new Movie(1, "Office"), new Movie(2, "Friends")};

        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode200_WhenRequestIsValidGet()
        {
            // Arrange
            IMoviesService testRepo = new TestRepository(Movies);
            Request request = new Request("GET", "/movies", null);
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(200, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseBodyWithMoviesInJsonFormat_WhenRequestIsValidGet()
        {
            // Arrange
            List<Movie> movies = new(){new Movie(1, "Office"), new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            Request request = new Request("GET", "/movies", null);
            var router = new Router(request, testRepo);
            var moviesInJsonFormat = "[{\"Id\":1,\"Title\":\"Office\"},{\"Id\":2,\"Title\":\"Friends\"}]";
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(moviesInJsonFormat, response.Body);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode404_WhenRequestIsInvalidGet()
        {
            // Arrange
            IMoviesService testRepo = new TestRepository(Movies);
            Request request = new Request("GET", "/users", null);
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(404, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWith201_WhenRequestIsValidPost()
        {
            // Arrange
            List<Movie> movies = new(){new Movie(1, "Office"), new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            Request request = new Request("POST", "/movies", "{\"Title\":\"Himym\"}");
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(201, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode404_WhenRequestIsInvalidPostUrl()
        {
            // Arrange
            IMoviesService testRepo = new TestRepository(Movies);
            Request request = new Request("POST", "/users", null);
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(404, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode400_WhenRequestBodyIsInvalidJson()
        {
            // Arrange
            IMoviesService testRepo = new TestRepository(Movies);
            Request request = new Request("POST", "/movies", "{\"Himym\"}");
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(400, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode400_WhenRequestContainsExistingMovie()
        {
            // Arrange
            List<Movie> movies = new(){new Movie(1, "Office"), new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            Request request = new Request("POST", "/movies", "{\"Title\":\"Office\"}");
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(400, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode200_WhenRequestIsValidPut()
        {
            // Arrange
            List<Movie> movies = new(){new Movie(1, "Office"), new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            Request request = new Request("PUT", "/movies/1", "{\"Title\":\"Himym\"}");
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(200, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode404_WhenRequestIsInvalidPut()
        {
            // Arrange
            IMoviesService testRepo = new TestRepository(Movies);
            Request request = new Request("PUT", "/users", null);
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(404, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode200_WhenRequestIsValidDelete()
        {
            // Arrange
            IMoviesService testRepo = new TestRepository(Movies);
            Request request = new Request("DELETE", "/movies/1", null);
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(200, response.StatusCode);
        }
        
        [Fact]
        public void Route_ShouldReturnResponseWithStatusCode404_WhenRequestIsInvalidDelete()
        {
            // Arrange
            IMoviesService testRepo = new TestRepository(Movies);
            Request request = new Request("DELETE", "/users", null);
            var router = new Router(request, testRepo);
            // Act
            var response = router.Route();
            // Assert
            Assert.Equal(404, response.StatusCode);
        }
        
    }
}