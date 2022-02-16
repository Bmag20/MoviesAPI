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
        public void GetAllMovies_ShouldReturnAllMoviesFromTheRepo()
        {
            // Arrange
            List<Movie> movies = new List<Movie>(){ new Movie(1, "Office"), new Movie(2, "Friends")};
            var serviceMock = new Mock<IMoviesService>();
            serviceMock.Setup(m => m.GetAllMovies()).Returns(movies);
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act
            var result = controller.GetAllMovies();
            // Assert
            Assert.Equal(movies, result);
        }
        
        [Fact]
        public void GetMovieById_ShouldReturnMovieReturnedByTheService_WhenValidIdIsPassed()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            var serviceMock = new Mock<IMoviesService>();
            serviceMock.Setup(m => m.GetMovieById(1)).Returns(movie);
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act
            var result = controller.GetMovieById(1);
            // Assert
            Assert.Equal(result, movie);
        }
        
        [Fact]
        public void GetMovieById_ShouldThrowException_WhenServiceReturnsNull()
        {
            // Arrange
            var serviceMock = new Mock<IMoviesService>();
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act and Assert
            Assert.Throws<MovieNotFoundException>(() => controller.GetMovieById(3));
        }
        
        [Fact]
        public void AddMovie_ShouldCallAddMovieMethodOfService_WhenValidMovieIsPassed()
        {
            // Arrange
            List<Movie> movies = new List<Movie>(){new Movie(1, "Office"), new Movie(2, "Friends")};
            var serviceMock = new Mock<IMoviesService>();
            serviceMock.Setup(m => m.GetAllMovies()).Returns(movies);
            MoviesController controller = new MoviesController(serviceMock.Object);
            var movie = new Movie("Himym");
            // Act
            controller.AddMovie(movie);
            // Assert
            serviceMock.Verify(m => m.AddMovie(movie));
        }
        
        [Fact]
        public void AddMovie_ShouldThrowException_WhenMovieAlreadyExists()
        {
            // Arrange
            List<Movie> movies = new List<Movie>(){new Movie(1, "Office"), new Movie(2, "Friends")};
            var serviceMock = new Mock<IMoviesService>();
            serviceMock.Setup(m => m.GetAllMovies()).Returns(movies);
            MoviesController controller = new MoviesController(serviceMock.Object);
            var newMovie = new Movie( "Office");
            // Act and Assert
            Assert.Throws<MovieAlreadyExistsException>(() => controller.AddMovie(newMovie));
        }
        
        [Fact]
        public void AddMovie_ShouldThrowException_WhenMovieNameIsEmpty()
        {
            // Arrange
            var serviceMock = new Mock<IMoviesService>();
            MoviesController controller = new MoviesController(serviceMock.Object);
            var newMovie = new Movie("");
            // Act and Assert
            Assert.Throws<MovieNameEmptyException>(() => controller.AddMovie(newMovie));
        }

        [Fact]
        public void UpdateMovie_ShouldCallTheUpdateMovieServiceMethod_WhenValidMovieIsPassed()
        {
            // Arrange
            List<Movie> movies = new List<Movie>(){new Movie(1, "Office"), new Movie(2, "Friends")};
            var serviceMock = new Mock<IMoviesService>();
            serviceMock.Setup(m => m.GetAllMovies()).Returns(movies);
            serviceMock.Setup(m => m.GetMovieById(1)).Returns(movies[0]);
            MoviesController controller = new MoviesController(serviceMock.Object);
            var updateMovie = new Movie("Himym");
            // Act
            controller.UpdateMovie(1, updateMovie);
            // Assert
            serviceMock.Verify(s => s.UpdateMovie(1, updateMovie));
        }
        
        [Fact]
        public void UpdateMovie_ShouldThrowException_WhenServiceReturnsNull()
        {
            // Arrange
            var movie = new Movie(1, "Office");
            List<Movie> movies = new List<Movie>(){movie, new Movie(2, "Friends")};
            var serviceMock = new Mock<IMoviesService>();
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act and Assert
            Assert.Throws<MovieNotFoundException>(() => controller.UpdateMovie(3, new Movie("Himym")));
        }
        
        [Fact]
        public void UpdateMovie_ShouldThrowException_WhenMovieNameIsEmpty()
        {
            // Arrange
            var serviceMock = new Mock<IMoviesService>();
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act and Assert
            Assert.Throws<MovieNameEmptyException>(() => controller.UpdateMovie(3, new Movie("")));
        }
        
        [Fact]
        public void UpdateMovie_ShouldThrowException_WhenMovieNameAlreadyExists()
        {
            // Arrange
            List<Movie> movies = new List<Movie>(){new Movie(1, "Office"), new Movie(2, "Friends")};
            var serviceMock = new Mock<IMoviesService>();
            serviceMock.Setup(m => m.GetAllMovies()).Returns(movies);
            serviceMock.Setup(m => m.GetMovieById(1)).Returns(movies[0]);
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act and Assert
            Assert.Throws<MovieAlreadyExistsException>(() => controller.UpdateMovie(1, new Movie("Friends")));
        }

        [Fact]
        public void DeleteMovie_ShouldCallDeleteMovieMethodOfService_WhenExistingMovieIdIsPassed()
        {
            // Arrange
            List<Movie> movies = new List<Movie>(){new Movie(1, "Office"), new Movie(2, "Friends")};
            var serviceMock = new Mock<IMoviesService>();
            serviceMock.Setup(m => m.GetAllMovies()).Returns(movies);
            serviceMock.Setup(m => m.GetMovieById(1)).Returns(movies[0]);
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act
            controller.DeleteMovie(1);
            // Assert
            serviceMock.Verify(s => s.DeleteMovie(1), Times.Once);
        }
        
        [Fact]
        public void DeleteMovie_ShouldThrowException_WhenServiceReturnsNull()
        {
            // Arrange
            var serviceMock = new Mock<IMoviesService>();
            MoviesController controller = new MoviesController(serviceMock.Object);
            // Act and Assert
            Assert.Throws<MovieNotFoundException>(() => controller.DeleteMovie(3));
        }
    }
}