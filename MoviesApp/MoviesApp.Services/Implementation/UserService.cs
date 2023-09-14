using CryptoService;
using CustomExceptions.UserCustomExeptions;
using Microsoft.IdentityModel.Tokens;
using MoviesApp.DataAccess.Abstraction;
using MoviesApp.Domain.Models;
using MoviesApp.DTOs.UserDto;
using MoviesApp.Services.Abstraction;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace MoviesApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string LoginUser(LoginUserDto loginUserDto)
        {
            if (string.IsNullOrEmpty(loginUserDto.Username) ||
                string.IsNullOrEmpty(loginUserDto.Password))
            {
                throw new UserDataException("Username and password are required fields!");
            }

            var userFromDb = _userRepository.LoginUser(loginUserDto.Username, StringHasher.Hash(loginUserDto.Password));

            if (userFromDb == null)
            {
                throw new UserNotFoundException("User not found!");
            }

            //Generate JWT Token
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes("Life is not life without motorbike");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(3),
                //signature configuration
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature),
                //payload
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("userFullName", $"{userFromDb.FirstName} {userFromDb.LastName}"),
                        new Claim("userId", $"{userFromDb.Id}"),
                        new Claim(ClaimTypes.Name, userFromDb.Username)
                    }
                )
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }
        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            {
                //1. validation
                ValidateUser(registerUserDto);

                //2. Hash password
                var passwordHash = StringHasher.Hash(registerUserDto.Password);

                //3. create new user
                var user = new User
                {
                    FirstName = registerUserDto.FirstName,
                    LastName = registerUserDto.LastName,
                    Username = registerUserDto.Username,
                    FavoriteGenre = registerUserDto.FavoriteGenre,
                    Password = passwordHash
                };

                _userRepository.Add(user);
            }
        }
        public void ChangePasswordUser(ChangePasswordUserDto changePasswordUserDto)
        {

            var userFromDb = _userRepository.GetUserByUsername(changePasswordUserDto.Username);

            ValidatePassword(changePasswordUserDto);

            // Hash and update the user's password in the database
            userFromDb.Password = StringHasher.Hash(changePasswordUserDto.NewPassword);
            _userRepository.ChangePassword(userFromDb, userFromDb.Password);

        }
        private void ValidateUser(RegisterUserDto registerUserDto)
        {
            if (registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                throw new UserDataException("Password must match!");
            }

            if (string.IsNullOrEmpty(registerUserDto.Username) ||
                string.IsNullOrEmpty(registerUserDto.Password) ||
                string.IsNullOrEmpty(registerUserDto.ConfirmPassword))
            {
                throw new UserDataException("Username and password are required fields!");
            }

            if (registerUserDto.Username.Length > 30)
            {
                throw new UserDataException("Username: Maximum length for username is 30 characters");
            }

            if (registerUserDto.FirstName.Length > 50)
            {
                throw new UserDataException("Maximum length for FirstName is 50 characters");
            }

            if (registerUserDto.LastName.Length > 50)
            {
                throw new UserDataException("Maximum length for LastName is 50 characters");
            }

            var userFromDb = _userRepository.GetUserByUsername(registerUserDto.Username);
            if (userFromDb != null)
            {
                throw new UserDataException($"The username {registerUserDto.Username} is already in use!");
            }
        }
        private void ValidatePassword(ChangePasswordUserDto changePasswordUserDto)
        {
            var userFromDb = _userRepository.GetUserByUsername(changePasswordUserDto.Username);

            if (userFromDb == null)
            {
                throw new UserNotFoundException("User not found!");
            }
            if (userFromDb.Password != StringHasher.Hash(changePasswordUserDto.OldPassword))
            {
                throw new UserNotFoundException("Current password is incorrect!");
            }

            if (string.IsNullOrEmpty(changePasswordUserDto.NewPassword))
            {
                throw new UserDataException("New Password is required!");
            }

            if (changePasswordUserDto.NewPassword.Length < 8)
            {
                throw new UserDataException("Password must be at least 8 characters long!");
            }
        }
    }
}
