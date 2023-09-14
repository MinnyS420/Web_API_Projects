using CustomExeptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Domain.Enums;
using MoviesApp.Domain.Models;
using MoviesApp.DTOs.MovieDto;
using MoviesApp.Services.Abstraction;

namespace MoviesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieSevice _movieSevice;
        public MovieController(IMovieSevice movieSevice)
        {
            _movieSevice = movieSevice;
        }

        [HttpGet] //localhost:[port]/api/Movie
        public IActionResult GetAllMovies()
        {
            try
            {
                return Ok(_movieSevice.GetAllMovies());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }

        [HttpGet("{id}")] //localhost:[port]/api/Movie
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var movieDto = _movieSevice.GetById(id);
                return Ok(movieDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "System error occurred, contact admin!");
            }
        }

        [HttpGet("findById")] //localhost:[port]/api/Movie
        public IActionResult GetMovieFromId([FromQuery] int id) 
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id can not be negative!");
                }

                var movieDto = _movieSevice.GetById(id);

                if(movieDto is null)
                {
                    return NotFound($"Movie with id: {id} does not exist");
                }
                return Ok(movieDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }

        [HttpPost("titles")] //localhost:[port]/api/Movie/titles
        public IActionResult GetTitlesFromMovies([FromBody] List<Movie> movies)
        {
            try
            {
                _movieSevice.GetTitlesFromMovies(movies);
                return Ok(movies);
            }
            catch (MovieDataException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "System error occurred, contact admin!");
            }
        }

        [HttpGet("filter")] //localhost:[port]/api/Movie/filter
        public IActionResult GetMoviesByGenreAndYear([FromQuery] Genre? genre, [FromQuery] int? year)
        {
            try
            {
                
                return Ok(_movieSevice.GetMoviesByGenreAndYear(genre, year));
            }
            catch (MovieDataException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "System error occurred, contact admin!");
            }
        }

        [HttpPost] //localhost:[port]/api/Movie
        public IActionResult AddMovie([FromBody] MovieDTO movieDto)
        {
            try
            {
                _movieSevice.AddMovie(movieDto);
                return StatusCode(201, "Movie Added!");
            }
            catch (MovieDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "System error occurred, contact admin!");
            }
        }

        [HttpPut] //localhost:[port]/api/Movie
        public IActionResult UpdateMovie([FromBody] UpdateMovieDTO updateMovieDto)
        {
            try
            {
                _movieSevice.UpdateMovie(updateMovieDto);
                return StatusCode(201, "Movie Updated!");
            }
            catch (MovieDataException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "System error occurred, contact admin!");
            }
        }

        [HttpDelete("{id}")] //localhost:[port]/api/Movie/{id}
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            try
            {
                _movieSevice.DeleteMovie(id);
                return Ok("Movie deleted successfully!");
            }
            catch (MovieDataException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "System error occurred, contact admin!");
            }
        }
        
        [HttpDelete("deleteById")] //localhost:[port]/api/Movie/deleteById
        public IActionResult DeleteMovieFromBody([FromBody] int id)
        {
            try
            {
                _movieSevice.DeleteMovie(id);
                return Ok("Movie deleted successfully!");
            }
            catch (MovieDataException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "System error occurred, contact admin!");
            }
        }
    }
}