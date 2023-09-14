using Microsoft.Extensions.Configuration;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.EntityImplementation
{
    public class MoviesRepository : IRepository<Movie>
    {
        private readonly MoviesAppDbContext _dbMovieContext;
        public MoviesRepository(MoviesAppDbContext dbMovieContext)
        {
            _dbMovieContext = dbMovieContext;
        }

        public void Add(Movie entity)
        {
            _dbMovieContext.Movies.Add(entity);
            _dbMovieContext.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _dbMovieContext.Movies.Remove(entity);
            _dbMovieContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _dbMovieContext.Movies.ToList();

        }

        public Movie GetById(int id)
        {
            return _dbMovieContext.Movies.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Movie entity)
        {
            _dbMovieContext.Movies.Update(entity);
            _dbMovieContext.SaveChanges();
        }
    }
}
