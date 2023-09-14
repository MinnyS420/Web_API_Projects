using MoviesApp.Domain.Enums;

namespace MoviesApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genre FavoriteGenre { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
