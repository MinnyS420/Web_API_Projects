using MoviesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        [Range(1900, 2100)] // Example range for the year
        public int Year { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
