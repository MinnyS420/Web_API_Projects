namespace MoviesApp.DTOs.UserDto
{
    public class ChangePasswordUserDto
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
