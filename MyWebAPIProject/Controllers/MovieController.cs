using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebAPIProject.Data;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MovieController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _applicationDbContext.Movies.OrderBy(m => m.Name).Select(m => m.Name).ToList();
            return Ok(movies);

        }
        [HttpGet("GetMoviesByGenre/{genreName}")]
        public IActionResult GetMoviesByGenre(string genreName)
        {
            var movies = _applicationDbContext.Movies.Where(m => m.Genres.Any(g => g.Name == genreName)).OrderBy(m=> m.Name).Select(m=> m.Name).ToList();
            if (string.IsNullOrWhiteSpace(genreName))
                return NotFound();
            return Ok(movies);
        }
        [HttpGet("GetMoviesOfADirector/{directorName}")]
        public IActionResult GetMoviesOfADirector(string directorName)
        {
            var movies = _applicationDbContext.Movies.Where(m => m.Director.Name.Contains(directorName)).OrderBy(m=> m.Name).Select(m=> m.Name).ToList();
            if (string.IsNullOrEmpty(directorName))
                return NotFound();
            return Ok(movies);

        }
        [HttpGet("GetMoviesOfAnActor/{actorName}")]
        public IActionResult GetMoviesOfAnActor(string actorName)
        {
            var movies = _applicationDbContext.Movies.Where(m => m.Actors.Any(a => a.Name.Contains(actorName))).OrderBy(a=> a.Name).Select(m=> m.Name).ToList();
            if (string.IsNullOrEmpty(actorName))
                return NotFound();
            return Ok(movies);
        }
        [HttpGet("GetActorsOfAMovie/{movieName}")]
        public IActionResult GetActorsOfAMovie(string movieName)
        {
            var actors = _applicationDbContext.Actors.Where(a => a.Movies.Any(m => m.Name.Contains(movieName))).OrderBy(m=> m.Name).Select(a=> a.Name).ToList();
            if (string.IsNullOrEmpty(movieName))
                return NotFound();
            return Ok(actors);
        }
    }
}
