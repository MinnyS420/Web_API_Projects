using MoviesApp.Domain.Models;
using MoviesApp.DTOs.MovieDto;

namespace MoviesApp.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToMovie(this MovieDTO movieDTO)
        {
            return new Movie
            {
                Title = movieDTO.Title,
                Genre = movieDTO.Genre,
                Year = movieDTO.Year,
                Description = movieDTO.Description,
            };
        }
        public static MovieDTO ToMovieDto(this Movie movie)
        {
            return new MovieDTO
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Year = movie.Year,
                Description = movie.Description,
            };
        }
        public static void UpdateToMovieDto(UpdateMovieDTO source, Movie destination)
        {
            destination.Title = source.Title;
            destination.Description = source.Description;
            destination.Year = source.Year;
            destination.Genre = source.Genre;
        }
    };
}
