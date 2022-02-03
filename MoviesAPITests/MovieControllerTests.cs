using System.Collections.Generic;
using Moq;
using MoviesAPI;
using MoviesAPI.Controller;
using MoviesAPI.Exceptions;
using MoviesAPI.Repository;
using Xunit;

namespace MoviesAPITests
{
    public class MovieControllerTests
    {

        [Fact]
        public void GetAllMovies_ReturnAllMoviesFromTheRepo()
        {
            // Arrange
            var serviceMock = new Mock<IMoviesService>();
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act
            var result = controller.GetAllMovies();
            // Assert
            serviceMock.Verify(x => x.GetAllMovies(), Times.Once);
        }
        
        [Fact]
        public void GetMovieById_ReturnMovieFromTheRepo()
        {
            // Arrange
            var serviceMock = new Mock<IMoviesService>();
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act
            var result = controller.GetMovieById(1);
            // Assert
            serviceMock.Verify(x => x.GetMovieById(1), Times.Once);
        }
        
        [Fact]
        public void GetMovieById_ThrowsExceptionWhenMovieNotFound()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            // Act and Assert
            Assert.Throws<MovieNotFoundException>(() => controller.GetMovieById(3));
        }
        
        [Fact]
        public void AddMovie_AddsMovieToTheRepo()
        {
            // Arrange
            List<Movie> movies = new List<Movie>(){ new Movie(1, "Office"), new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            var movie = new Movie("Himym");
            // Act
            controller.AddMovie(movie);
            // Assert
            Assert.Equal(3, testRepo.GetAllMovies().Count);
        }
        
        [Fact]
        public void AddMovie_ThrowsExceptionWhenMovieAlreadyExists()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            var newMovie = new Movie( "Office");
            // Act and Assert
            Assert.Throws<MovieAlreadyExistsException>(() => controller.AddMovie(newMovie));
        }
        
        // [Fact]
        // public void AddMovie_ThrowsExceptionWhenMovieNameIsNull()
        // {
        //     // Arrange
        //     var movie = new Movie(1, "Office");
        //     List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
        //     IMoviesRepository testRepo = new TestRepository(movies);
        //     MoviesController controller = new MoviesController(testRepo);
        //     var newMovie = new Movie(null);
        //     // Act and Assert
        //     Assert.Throws<Exception>(() => controller.AddMovie(newMovie));
        // }

        [Fact]
        public void UpdateMovie_UpdatesMovieInTheRepo()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            // Act
            controller.UpdateMovie(1, new Movie(1, "Himym"));
            // Assert
            Assert.Equal("Himym", testRepo.GetMovieById(1).Title);
        }
        
        [Fact]
        public void UpdateMovie_ThrowsExceptionWhenMovieNotFound()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            // Act and Assert
            Assert.Throws<MovieNotFoundException>(() => controller.UpdateMovie(3, new Movie("Himym")));
        }
        
        [Fact]
        public void UpdateMovie_ThrowsExceptionWhenMovieNameAlreadyExists()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            // Act and Assert
            Assert.Throws<MovieAlreadyExistsException>(() => controller.UpdateMovie(1, new Movie("Friends")));
        }
        
        [Fact]
        public void DeleteMovie_DeletesMovieFromTheRepo()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            // Act
            controller.DeleteMovie(1);
            // Assert
            Assert.Single(testRepo.GetAllMovies());
        }
        
        [Fact]
        public void DeleteMovie_ThrowsExceptionWhenMovieNotFound()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            IMoviesService testRepo = new TestRepository(movies);
            MoviesController controller = new MoviesController(testRepo);
            // Act and Assert
            Assert.Throws<MovieNotFoundException>(() => controller.DeleteMovie(3));
        }
    }
}