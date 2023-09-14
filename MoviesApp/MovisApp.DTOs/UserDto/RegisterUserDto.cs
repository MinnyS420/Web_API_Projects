using MoviesApp.Domain.Enums;

namespace MoviesApp.DTOs.UserDto
{
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Genre FavoriteGenre { get; set; }
    }
}

