using MoviesApp.DataAccess.Abstraction;
using MoviesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.EntityImplementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MoviesAppDbContext _movieAppDbContext;
        public UserRepository(MoviesAppDbContext movieAppDbContext)
        {
            _movieAppDbContext = movieAppDbContext;
        }

        public void Add(User entity)
        {
            _movieAppDbContext.Users.Add(entity);
            _movieAppDbContext.SaveChanges();
        }
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }
        public User GetById(int id)
        {
            return _movieAppDbContext.Users
                .SingleOrDefault(user => user.Id == id);
        }
        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(User entity)
        {

        }
        public User GetUserByUsername(string username)
        {
            return _movieAppDbContext.Users.SingleOrDefault(user => user.Username == username);
        }
        public User LoginUser(string username, string hashedPassword)
        {
            return _movieAppDbContext.Users.FirstOrDefault(user =>
                        user.Username.ToLower() == username.ToLower() &&
                        user.Password == hashedPassword);
        }
        public void ChangePassword(User user, string newPassword)
        {
            user.Password = newPassword;
            _movieAppDbContext.SaveChanges();
        }
    }
}
