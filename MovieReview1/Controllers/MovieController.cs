using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Models;
using MovieReview.Core.Interfaces;

namespace MovieReview.Server.Controllers
{
    [Route("api/v1/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieServices _movieServices;
        private ILogger _logger;

        public MovieController(IMovieServices movieServices, ILoggerFactory loggerFactory) 
        {
            _movieServices = movieServices;
            _logger = loggerFactory.CreateLogger<MovieController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            _logger.LogError("Someone asked for all movie list");
            List<Movie> movies = await _movieServices.GetAllMovies();
            if(movies != null)
            {
                return Ok(movies);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            Movie movie = await _movieServices.GetMovie(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return BadRequest();
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetMovieByName(string name)
        {
            Movie movie = await _movieServices.GetMovieByName(name);
            if (movie != null)
            {
                return Ok(movie);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(Movie movie)
        {
            bool result = await _movieServices.CreateMovie(movie);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            bool result = await _movieServices.UpdateMovie(movie);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            bool result = await _movieServices.DeleteMovie(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
