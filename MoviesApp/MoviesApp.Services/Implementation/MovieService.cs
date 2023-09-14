using CustomExeptions;
using MoviesApp.DataAccess;
using MoviesApp.Domain.Enums;
using MoviesApp.Domain.Models;
using MoviesApp.DTOs.MovieDto;
using MoviesApp.Mappers;
using MoviesApp.Services.Abstraction;

namespace MoviesApp.Services.Implementation
{
    public class MovieService : IMovieSevice
    {
        private readonly IRepository<Movie> _movieRepository;
        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public List<MovieDTO> GetAllMovies()
        {
            var moviesFromDb = _movieRepository.GetAll();
            if (moviesFromDb == null)
            {
                throw new MovieDataException("We don't have movies. Sorry!");
            }
            return moviesFromDb.Select(movie => movie.ToMovieDto()).ToList();
        }
        public MovieDTO GetById(int id)
        {
            if (id == 0)
            {
                throw new MovieDataException("The id can not be negative!");
            }

            var movieFromDb = _movieRepository.GetById(id);

            if (movieFromDb is null)
            {
                throw new MovieDataException($"Movie with id {id} does not exist");
            }

            return movieFromDb.ToMovieDto();
        }
        public List<string> GetTitlesFromMovies(List<Movie> movies)
        {
            if (movies is null || movies.Count == 0)
            {
                throw new MovieDataException("Invalid movie data!");
            }

            List<string> titles = movies.Select(x => x.Title).ToList();
            return titles;
        }
        public List<MovieDTO> GetMoviesByGenreAndYear(Genre? genre, int? year)
        {
            var filteredMovies = GetAllMovies();

            if (filteredMovies.Count == 0)
            {
                throw new MovieDataException("No movies found!");
            }
            if (genre != null)
            {
                filteredMovies = filteredMovies.Where(m => m.Genre == genre).ToList();
            }
            if (year != null)
            {
                filteredMovies = filteredMovies.Where(m => m.Year == year).ToList();
            }

            return filteredMovies;
        }
        public void AddMovie(MovieDTO addMovieDto)
        {
            if (string.IsNullOrEmpty(addMovieDto.Title))
            {
                throw new MovieDataException("Title is required field");
            }
            if (addMovieDto.Title.Length > 50)
            {
                throw new MovieDataException("Title can not contain more than 50 characters");
            }

            var newMovie = addMovieDto.ToMovie();
            _movieRepository.Add(newMovie);
        }
        public void UpdateMovie(UpdateMovieDTO updateMovieDto)
        {
            var movieFromDb = _movieRepository.GetById(updateMovieDto.Id);

            if (movieFromDb is null)
            {
                throw new MovieDataException($"Movie was not found");
            }

            if (movieFromDb.Title.Length > 50)
            {
                throw new MovieDataException("Title can not contain more than 50 characters");
            }

            MovieMapper.UpdateToMovieDto(updateMovieDto, movieFromDb);

            _movieRepository.Update(movieFromDb);
        }
        public void DeleteMovie(int id)
        {
            if (id <= 0)
            {
                throw new MovieDataException("The id can not be negative!");
            }

            var movieFromDb = _movieRepository.GetById(id);
            if (movieFromDb is null)
            {
                throw new MovieDataException($"Movie with id {id} does not exist");
            }

            _movieRepository.Delete(movieFromDb);
        }
    }
}