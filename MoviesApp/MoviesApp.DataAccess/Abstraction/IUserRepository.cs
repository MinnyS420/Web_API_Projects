using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Abstraction
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string hashedPassword);
        void ChangePassword(User user, string newPassword);
    }
}
