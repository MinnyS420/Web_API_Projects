using MoviesApp.DTOs.UserDto;

namespace MoviesApp.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginUserDto loginUserDto);
        void ChangePasswordUser(ChangePasswordUserDto changePasswordUserDto);
    }
}
