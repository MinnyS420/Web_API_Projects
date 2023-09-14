using CryptoService;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Enums;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess
{
    public class MoviesAppDbContext : DbContext
    {
        public MoviesAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //MOVIE

            //validations
            modelBuilder.Entity<Movie>()
               .Property(x => x.Title)
               .IsRequired();

            modelBuilder.Entity<Movie>()
               .Property(x => x.Year)
               .IsRequired();

            modelBuilder.Entity<Movie>()
               .Property(x => x.Genre)
               .IsRequired();

            modelBuilder.Entity<Movie>()
               .Property(x => x.Description)
               .HasMaxLength(250);

            //relations
            modelBuilder.Entity<Movie>()
                .HasOne(x => x.User)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.UserId);

            //USER

            //validations
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
               .Property(x => x.Username)
               .HasMaxLength(30)
               .IsRequired();

            //Seed

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Draaven",
                    LastName = "Dunklord",
                    Username = "DravenOut",
                    Password = StringHasher.Hash("draven123"),
                    Movies = new List<Movie>(),
                    FavoriteGenre = Genre.Action
                });
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 2,
                    FirstName = "Darius",
                    LastName = "Dunklord",
                    Username = "ddunkelord",
                    Password = StringHasher.Hash("darius123"),
                    Movies = new List<Movie>(),
                    FavoriteGenre = Genre.Thriller
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Foo",
                    Description = "Bar",
                    Genre = Domain.Enums.Genre.Action,
                    Year = 2014,
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 2,
                    UserId= 2,
                    Title = "Boo",
                    Description = "Bar",
                    Genre = Domain.Enums.Genre.Thriller,
                    Year = 2015,
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 3,
                    UserId = 2,
                    Title = "Hoo",
                    Description = "Bar",
                    Genre = Domain.Enums.Genre.Comedy,
                    Year = 2016,
                });
        }
    }
}
