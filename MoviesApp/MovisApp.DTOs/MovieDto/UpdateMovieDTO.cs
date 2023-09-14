using MoviesApp.Domain.Enums;

namespace MoviesApp.DTOs.MovieDto
{
    public class UpdateMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
